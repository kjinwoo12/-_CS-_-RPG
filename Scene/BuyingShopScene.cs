
using System;
using System.Threading;
using System.Collections.Generic;

public class BuyingShopScene : IScene
{
    int minProductCursorTop;
    int alertCursorTop;
    int selectedProductIndex;
    IScene nextScene;

    public BuyingShopScene() : this(0)
    {
    }

    public BuyingShopScene(int selectedProductIndex)
    {
        this.selectedProductIndex = selectedProductIndex;
    }

    public void OnShow()
    {
        Console.WriteLine("상점(*구매, 판매)");
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
        ShowGold();
        Console.WriteLine();
        ShowProductItems();
        Console.WriteLine("\n마을로 돌아가려면 [1]을 눌러주세요.");
        Console.WriteLine("아이템을 선택하려면 방향키[↑,↓]를 입력해주세요.");
        Console.WriteLine("구매/판매 텝으로 넘어가려면 방향키[←,→]를 입력해주세요.");
        Console.WriteLine("아이템을 구매하려면 [space]를 눌러주세요.");
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

    void ShowProductItems()
    {
        Console.WriteLine("[아이템 목록]");
        Console.WriteLine("가격 및 이름\t\t| 설명");

        List<Product> products = ProductManager.instance.products;
        if (products.Count == 0)
        {
            Console.WriteLine("(......Empty......)");
            return;
        }
        PlayerState playerState = GameManager.instance.playerState;
        minProductCursorTop = Console.CursorTop;
        foreach (Product product in products)
        {
            if (product.isSoldOut)
            {
                Console.WriteLine($"- {product.price}G [매진]{product.defaultItemInstance.name}");
            }
            else
            {
                Console.WriteLine($"- {product.price}G {product.defaultItemInstance.name} \t| {product.defaultItemInstance.description}");
            }
        }
    }

    void CleanInputBuffer()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }

    void ShowCursorInput()
    {
        PlayerState playerState = GameManager.instance.playerState;
        List<Product> products = ProductManager.instance.products;
        while (true)
        {
            if (products.Count <= selectedProductIndex)
            {
                selectedProductIndex = products.Count - 1;
            }

            if (products.Count > 0)
            {
                Console.SetCursorPosition(0, minProductCursorTop + selectedProductIndex);
                Console.Write("*");
            }
            
            CleanInputBuffer();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (selectedProductIndex <= 0)
                {
                    continue;
                }

                Console.SetCursorPosition(0, minProductCursorTop + selectedProductIndex);
                Console.Write("-");
                selectedProductIndex -= 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (products.Count <= selectedProductIndex)
                {
                    selectedProductIndex = products.Count - 1;
                    continue;
                }

                Console.SetCursorPosition(0, minProductCursorTop + selectedProductIndex);
                Console.Write("-");
                selectedProductIndex += 1;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                nextScene = new SellingShopScene();
                break;
            }
            else if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                Product product = products[selectedProductIndex];
                if (product.isSoldOut)
                {
                    Console.SetCursorPosition(0, alertCursorTop);
                    Console.WriteLine("아이템이 매진되었습니다.");
                    Thread.Sleep(500);
                }
                else if (playerState.gold < product.price)
                {
                    Console.SetCursorPosition(0, alertCursorTop);
                    Console.WriteLine("골드가 부족합니다.");
                    Thread.Sleep(500);
                }
                else
                {
                    Console.SetCursorPosition(0, alertCursorTop);
                    Console.WriteLine("구매 완료");
                    playerState.inventory.Add(product.CreateItemInstance());
                    playerState.gold -= product.price;
                    Thread.Sleep(500);
                }
                nextScene = new BuyingShopScene(selectedProductIndex);
                break;
            }
            else if (keyInfo.KeyChar == '1')
            {
                nextScene = new SpartaTownScene();
                break;
            }
            else if (keyInfo.KeyChar == '2')
            {
                playerState.gold += 1000000;
                nextScene = new BuyingShopScene();
                break;
            }
        }
    }
}