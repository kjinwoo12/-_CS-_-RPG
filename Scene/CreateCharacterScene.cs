using System;

public class CreateCharacterScene : IScene
{
    public void OnShow()
    {
        Console.WriteLine("        _________  ___  _________  ________  ________   ___  ________ ");
        Console.WriteLine("       |\\___   ___\\\\  \\|\\___   ___\\\\   __  \\|\\   ___  \\|\\  \\|\\   ____\\ ");
        Console.WriteLine("       \\|___ \\  \\_\\ \\  \\|___ \\  \\_\\ \\  \\|\\  \\ \\  \\\\ \\  \\ \\  \\ \\  \\___|");
        Console.WriteLine("            \\ \\  \\ \\ \\  \\   \\ \\  \\ \\ \\  \\ \\  \\ \\  \\\\ \\  \\ \\  \\ \\  \\____ ");
        Console.WriteLine("             \\ \\__\\ \\ \\__\\   \\ \\__\\ \\ \\__\\ \\__\\ \\__\\\\ \\__\\ \\__\\ \\_______\\       ⢢⣿⢻ ");
        Console.WriteLine("              \\|__|  \\|__|    \\|__|  \\|__|\\|__|\\|__| \\|__|\\|__|\\|_______|       ⢼⡯⡨⠀⠀⣺⡿⠃");
        Console.WriteLine("                 ⠀                                                          ⢈⣀⣌⡀⣼⡓⠆⢀⡀⣿⢂⠁ ⢨⡟⡃ ⢰⡦");
        Console.WriteLine("                                                            ⢸⢂⡮⣴⢤⣖⣀⣆⢠⡀⡄⡁⣀⢷⠳⡷⡭⡫⠮⡱⡮⣟⣛⠻⠣⣭⡢⢤⡘⡣⠀⡿⡁⡽⠃⠀⠨⠀⠀⠀⠀⠄⠀⠀");
        Console.WriteLine("                                                            ⣸⣿⣿⣿⣿⣷⣿⣾⣷⣯⣮⣽⣬⣩⣃⣋⡚⢙⠍⠳⠽⠍⠉⠛⠃⠢⠌⢩⢑⠊⠝⠤⢂⡝⡠⢄⡐⠀⠀⠀⡀⠀⠀⠁");
        Console.WriteLine("                                                            ⢛⣿⣿⣿⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣶⣦⣦⣴⣤⣀⣄⣀⡈⡈⠈⠐⠐⠈⠄⢈⠈⠡⠀⠀⠀⠐⠀");
        Console.WriteLine("                                                            ⢨⣿⣿⢿⣯⣿⣽⣷⣿⣟⣿⣻⣿⣻⣿⡿⣿⣿⣻⡿⣿⢿⣿⣻⣯⣿⣻⢿⣝⣿⣻⣟⢿⣛⣟⢞⣗⠝⠁⡀⡀⢂⠐⠀");
        Console.WriteLine("                                                            ⢑⣿⣻⣟⣿⣻⣻⢯⣟⣿⡻⣟⢿⡫⢟⡛⢿⠾⡻⡟⢿⢻⢏⡿⡳⡫⡥⢕⢆⡥⣨⡉⣁⢁⠅⠣⠐⢌⠒⡀⢊⢄⢑⠑");
        Console.WriteLine("                                                              ⢵⡮⣾⢵⢣⡏⣵⡵⣬⣬⣡⡣⣝⣇⢟⣝⢛⢞⢜⣑⢱⢢⠪⢎⠾⡘⣧⢲⡬⣮⡺⣜⢭⢫⡛⡺⢌⢏⡺⡱⡣⣮⣅");

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("          원하시는 캐릭터의 이름을 설정해주세요.");
        Console.Write("          >> ");
        string name = Console.ReadLine();

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"당신의 캐릭터 [{name}]의 직업을 설정해주세요.");
        Console.WriteLine();
        Console.WriteLine("1. 워리어");
        Console.WriteLine("2. 시프");
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.KeyChar == '1')
            {
                GameManager.instance.playerCharacter = new Warrior(name);
                break;
            }
            else if(keyInfo.KeyChar == '2')
            {
                GameManager.instance.playerCharacter = new Thief(name);
                break;
            }
        }
    }

    public IScene GetNextScene()
    {
        return new SpartaTownScene();
    }
}