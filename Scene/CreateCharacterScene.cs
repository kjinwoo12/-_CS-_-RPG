using System;

public class CreateCharacterScene : IScene
{
    public void OnShow()
    {
        Console.WriteLine("원하시는 캐릭터의 이름을 설정해주세요.");
        Console.Write(">> ");
        string name = Console.ReadLine();

        Console.Clear();
        Console.WriteLine($"당신의 캐릭터 [{name}]의 직업을 설정해주세요.");
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