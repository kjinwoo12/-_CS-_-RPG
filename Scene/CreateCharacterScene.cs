using System;

public class CreateCharacterScene : IScene
{
    public void OnShow()
    {
        Console.WriteLine(" ________  ___  ___  ________  _______   ________           _______    ________ ");
        Console.WriteLine("|\\   ____\\|\\  \\|\\  \\|\\   __  \\|\\   ___\\  |\\   __  \\        |\\   ___\\  |\\_____  \\");
        Console.WriteLine("\\ \\  \\___|\\ \\  \\\\\\  \\ \\  \\|\\  \\ \\  \\__/  \\ \\  \\|\\  \\       \\ \\  \\__/   \\|___/  /|");
        Console.WriteLine(" \\ \\_____  \\ \\  \\\\\\  \\ \\   ____\\ \\   __\\  \\ \\   _  _\\       \\ \\   __\\      /  / / ");
        Console.WriteLine("  \\|____|\\  \\ \\  \\\\\\  \\ \\  \\___|\\ \\  \\_/__ \\ \\  \\\\  \\|       \\ \\  \\_/__   /  /_/__ ");
        Console.WriteLine("    ____\\_\\  \\ \\_______\\ \\__\\    \\ \\______\\ \\ \\__\\\\ _\\        \\ \\______\\  \\________\\ ");
        Console.WriteLine("   |\\_________\\|_______|\\|__|     \\|_______| \\|__|\\|__|        \\|_______| \\|_______|");
        Console.WriteLine("   \\|_________|");
        Console.WriteLine();
        Console.WriteLine("  ________  ________  ________");
        Console.WriteLine(" |\\   __  \\|\\   __  \\|\\   ____\\");
        Console.WriteLine(" \\ \\  \\|\\  \\ \\  \\|\\  \\ \\  \\___| ");
        Console.WriteLine("  \\ \\   _  _\\ \\   ____\\ \\  \\  ___ ");
        Console.WriteLine("   \\ \\  \\\\  \\\\ \\  \\___|\\ \\  \\|\\  \\");
        Console.WriteLine("    \\ \\__\\\\ _\\\\ \\__\\    \\ \\_______\\");
        Console.WriteLine("     \\|__|\\|__|\\|__|     \\|_______|");
        Console.WriteLine();
        Console.WriteLine(); 
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(" 원하시는 캐릭터의 이름을 설정해주세요.");
        Console.Write(" >> ");
        int x = Console.CursorLeft;
        int y = Console.CursorTop;
        AsciiArt.Draw("img\\Bob.png", 43, 9, 40);
        Console.SetCursorPosition(x, y);




        
        string name = Console.ReadLine();

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"                                     당신의 캐릭터 [{name}]의 직업을 설정해주세요.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("                                                    1. 워리어");
        Console.WriteLine("                                                    2. 시프");
        Console.WriteLine("                                                    3. 몽크") ;
        Console.WriteLine("                                                    4. 마법사");
        Console.WriteLine("                                                    5. 아처");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        AsciiArt.Draw("img\\CharacterJobSelection.png", 28, 13, 60);




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
            else if(keyInfo.KeyChar == '3')
            {
                GameManager.instance.playerCharacter = new Monk(name);
                break;

            }
            else if (keyInfo.KeyChar == '4')
            {
                GameManager.instance.playerCharacter = new Magician(name);
                break;

            }
            else if (keyInfo.KeyChar == '5')
            {
                GameManager.instance.playerCharacter = new Archer(name);
                break;

            }
        }
    }

    public IScene GetNextScene()
    {
        return new SpartaTownScene();
    }
}