using System.Threading;
using System;
public class SpartaTownScene : IScene
{
    int actNum = 0;
    IScene nextScene = null;
    public void OnShow()
    {
        Console.Clear();
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("1. 상태 보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");
        Console.WriteLine("4. 던전");
        Console.WriteLine("5. 여관");
        Console.WriteLine("\n원하시는 행동에 맞는 번호를 눌러주세요.");
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.KeyChar == '1')
            {
                nextScene = new PlayerInfoScene();
                break;
            }
            else if (keyInfo.KeyChar == '2')
            {
                nextScene = new InventoryScene();
                break;
            }
            else if (keyInfo.KeyChar == '3')
            {
                nextScene = new BuyingShopScene();
                break;
            }
            else if (keyInfo.KeyChar == '4')
            {
                nextScene = new DungeonSelectionScene();
                break;
            }
            else if (keyInfo.KeyChar == '5')
            {
                nextScene = new HotelScene();
                break;
            }
        }
    }

    public IScene GetNextScene()
    {
        return nextScene;
    }
}