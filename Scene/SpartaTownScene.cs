using System.Threading;
using System;
public class SpartaTownScene : IScene
{
    int actNum = 0;
    IScene nextScene = null;
    public void OnShow()
    {

        Console.Clear();

        Console.WriteLine("         ");
        Console.WriteLine("         ");
        Console.WriteLine("         ");

        Console.WriteLine("      ┌──────────────────────────────────────────────┐    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⣀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │            Welcome to Sparta Town            │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │──────────────────────────────────────────────│    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣉⣹⣿⣿⣿⣏⣉⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣤⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.Write("      │                  ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("1. 상태 보기");
        Console.ResetColor();
        Console.WriteLine("                │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⠀⢀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⠖⠁⠶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.Write("      │                  ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("2. 인벤토리");
        Console.ResetColor();
        Console.WriteLine("                 │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⡇⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⢸⣿⡟⠛⠛⣿⣿⣿⣿⣿⣿⣿⣿⡟⠛⢻⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.Write("      │                  ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("3. 상점");
        Console.ResetColor();
        Console.WriteLine("                     │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢻⣧⣄⠀⣤⣾⣿⣿⡇⠀⠀⣤⡀⢹⣿⣿⡿⠀⣤⡀⠀⢸⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢹⣿⠀⣿⣿⣿⣿⣿⣆⣀⠿⠃⠸⠿⠿⠷⠀⠿⢇⣰⣾⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.Write("      │                  ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("4. 던전");
        Console.ResetColor();
        Console.WriteLine("                     │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⣿⣿⣿⣿⣿⣿⣿⣤⠀⠀⠀⠀⠀⠀⣤⣾⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣼⣿⣤⣿⠛⢻⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣤⣤⣤⣤⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.Write("      │                  ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("5. 여관");
        Console.ResetColor();
        Console.WriteLine("                     │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡏⠀⠀⠀⠰⠿⠿⢿⣿⣿⡿⣇⣀⣀⣀⣀⣀⣿⣿⡿⠏⠀⠀⠉⠉⠀⠀⠰⠖⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠉⠉⠿⠿⠿⠿⠿⠿⠿⣿⡏⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⣶⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      └──────────────────────────────────────────────┘    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      ┌──────────────────────────────────────────────┐    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢻⣿⠿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⣿⣿⣿⣿⣿⢀⣀⣀⣀⣀⣀⣀⣀⢀⣀⣿⣇⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠿⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡟⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡆⠀⠀⠀⠀⠀⠀⢰⡦⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │    원하시는 행동에 맞는 번호를 눌러주세요.   │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⣿⣿⣿⣿⡟⠉⠙⠛⠛⢿⣿⣿⣿⠛⠛⠛⠛⢻⣿⣿⣿⣿⣿⡟⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⣿⣿⣿⡏⠁⠀⠀⠀⠀⢸⣿⣿⣿⠀⠀⠀⠀⠀⠉⣿⣿⣿⣿⣇⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      │                                              │    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⠿⠶⠿⠿⠿⠷⠶⠶⠶⠶⠶⠾⠿⠿⠿⠶⠶⠶⠶⠶⠶⠿⠿⠿⠿⠿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine("      └──────────────────────────────────────────────┘    ");
        Console.Write("      입력 >> ");


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