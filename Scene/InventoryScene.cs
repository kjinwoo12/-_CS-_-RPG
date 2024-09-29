
using System;

public class InventoryScene : IScene
{
    int minInventoryCursorTop;
    int alertCursorTop;
    int selectedItemIndex;
    IScene nextScene;

    public InventoryScene() : this(0)
    {
    }

    public InventoryScene(int selectedItemIndex)
    {
        this.selectedItemIndex = selectedItemIndex;
    }

    public void OnShow()
    {
        Console.WriteLine("인벤토리");
        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
        ShowGold();
        ShowEquipedItems();
        Console.WriteLine();
        ShowInventoryItems();
        Console.WriteLine("\n마을로 돌아가려면 [1]을 눌러주세요.");
        Console.WriteLine("아이템을 선택하려면 방향키[↑,↓]를 입력해주세요.");
        Console.WriteLine("아이템을 장비 또는 사용하려면 [space]를 눌러주세요.");
        alertCursorTop = Console.CursorTop + 1;

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

    void ShowEquipedItems()
    {
        Console.WriteLine("[장비중인 아이템 목록]");
        Console.WriteLine("슬롯 이름 \t| 이름 \t| 설명");

        PlayerCharacter playerCharacter = GameManager.instance.playerCharacter;
        if(playerCharacter.equipmentComponent.equipSlot.Count == 0)
        {

            Console.WriteLine("(......Empty......)");
            return;
        }


        foreach (string slotName in playerCharacter.equipmentComponent.equipSlot.Keys)
        {
            Console.WriteLine($"{slotName} \t|{playerCharacter.equipmentComponent.equipSlot[slotName].name} \t| {playerCharacter.equipmentComponent.equipSlot[slotName].description}");
        }
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
            if (item is IEquipableItem && playerCharacter.equipmentComponent.equipSlot.ContainsValue((IEquipableItem)item))
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
            else if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                if (playerState.inventory.Count <= 0)
                {
                    continue;
                }
                IItem item = playerState.inventory[selectedItemIndex];
                if (item is IEquipableItem)
                {
                    if(playerCharacter.equipmentComponent.IsEquippedItem((IEquipableItem)item))
                    {
                        playerCharacter.equipmentComponent.Unequip(((IEquipableItem)item).slotName);
                    }
                    else
                    {
                        playerCharacter.equipmentComponent.Equip((IEquipableItem)item);
                    }
                }
                else if(item is IConsumableItem)
                {
                    Console.SetCursorPosition(0, alertCursorTop);
                    playerCharacter.ConsumeItem((IConsumableItem)item);
                    playerState.inventory.Remove(item);
                }
                nextScene = new InventoryScene(selectedItemIndex);
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