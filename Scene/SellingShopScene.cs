
using System;

public class SellingShopScene : IScene
{
    int minInventoryCursorTop;
    int selectedItemIndex;
    IScene nextScene;

    public SellingShopScene() : this(0)
    {
    }

    public SellingShopScene(int selectedItemIndex)
    {
        this.selectedItemIndex = selectedItemIndex;
    }

    public void OnShow()
    {
        Console.WriteLine("상점(구매, *판매)");
        Console.WriteLine("보유중인 아이템을 판매할 수 있는 상점입니다.\n");
        ShowGold();
        Console.WriteLine();
        ShowInventoryItems();
        Console.WriteLine("\n마을로 돌아가려면 [1]을 눌러주세요.");
        Console.WriteLine("아이템을 선택하려면 방향키[↑,↓]를 입력해주세요.");
        Console.WriteLine("구매/판매 텝으로 넘어가려면 방향키[←,→]를 입력해주세요.");
        Console.WriteLine("아이템을 판매하려면 [space]를 눌러주세요.");

        ShowCursorInput();
    }

    public IScene GetNextScene()
    {
        return nextScene;
    }
    void ShowGold()
    {
        PlayerState playerState = GameManager.instance.playerState;
        Console.WriteLine("[보유 골드]");
        Console.WriteLine($"{playerState.gold} G");
    }

    void ShowInventoryItems()
    {
        Console.WriteLine("[소유중인 아이템 목록]");
        Console.WriteLine("이름 \t| 설명");

        PlayerCharacter playerCharacter = GameManager.instance.playerCharacter;
        PlayerState playerState = GameManager.instance.playerState;
        if (playerState.inventory.Count == 0)
        {
            Console.WriteLine("(......Empty......)");
            return;
        }

        minInventoryCursorTop = Console.CursorTop;
        foreach (IItem item in playerState.inventory)
        {
            Console.Write("- ");
            if (item is IEquipableItem &&
                playerCharacter.equipmentComponent.IsEquippedItem((IEquipableItem)item))
            {
                Console.Write("[E]");
            }
            Console.WriteLine($"{item.name} \t| {item.description}");
        }
    }

    void ShowCursorInput()
    {
        PlayerCharacter playerCharacter = GameManager.instance.playerCharacter;
        PlayerState playerState = GameManager.instance.playerState;
        while (true)
        {
            if (playerState.inventory.Count <= selectedItemIndex)
            {
                selectedItemIndex = playerState.inventory.Count - 1;
            }

            if (playerState.inventory.Count > 0)
            {
                Console.SetCursorPosition(0, minInventoryCursorTop + selectedItemIndex);
                Console.Write("*");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if(selectedItemIndex <= 0)
                {
                    continue;
                }

                Console.SetCursorPosition(0, minInventoryCursorTop + selectedItemIndex);
                Console.Write("-");
                selectedItemIndex -= 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (playerState.inventory.Count-1 <= selectedItemIndex)
                {
                    continue;
                }

                Console.SetCursorPosition(0, minInventoryCursorTop + selectedItemIndex);
                Console.Write("-");
                selectedItemIndex += 1;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                nextScene = new BuyingShopScene();
                break;
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                IItem item = playerState.inventory[selectedItemIndex];
                if (item is IEquipableItem &&
                    playerCharacter.equipmentComponent.IsEquippedItem((IEquipableItem)item))
                {
                    playerCharacter.equipmentComponent.Unequip(((IEquipableItem)item).slotName);
                }
                if(ProductManager.instance.sellingInfo.TryGetValue(item.name, out int sellingPrice))
                {
                    playerState.gold += sellingPrice;
                    playerState.inventory.Remove(item);
                }

                nextScene = new SellingShopScene(selectedItemIndex);
                break;
            }
            else if(keyInfo.KeyChar == '1')
            {
                nextScene = new SpartaTownScene();
                break;
            }
        }
    }
}