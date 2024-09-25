using System;

public class DungeonSelectionScene : IScene
{
    IScene nextScene;
    public IScene GetNextScene()
    {
        return nextScene;
    }

    public void OnShow()
    {
        Console.WriteLine("던전 입장");
        Console.WriteLine("어떤 몬스터를 토벌할지 골라주세요.");

        Console.WriteLine("1. 고블린");
        Console.WriteLine("2. 뱀파이어");
        Console.WriteLine("3. 드래곤");
        Console.WriteLine("4. 나가기");

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if(keyInfo.KeyChar == '1')
            {
                nextScene = new DungeonScene(new Goblin());
                break;
            }
            else if (keyInfo.KeyChar == '2')
            {
                nextScene = new DungeonScene(new Vampire());
                break;
            }
            else if (keyInfo.KeyChar == '3')
            {
                nextScene = new DungeonScene(new Dragon());
                break;
            }
            else if (keyInfo.KeyChar == '4')
            {
                nextScene = new SpartaTownScene();
                break;
            }
        }
    }
}