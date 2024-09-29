using System;
using System.Collections.Generic;

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
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new Goblin("고블린1"));
                monsters.Add(new Goblin("고블린2"));
                monsters.Add(new Goblin("고블린3"));
                nextScene = new DungeonScene(monsters);
                break;
            }
            else if (keyInfo.KeyChar == '2')
            {
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new Vampire());
                monsters.Add(new Vampire());
                monsters.Add(new Vampire());
                nextScene = new DungeonScene(monsters);
                break;
            }
            else if (keyInfo.KeyChar == '3')
            {
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new Dragon());
                monsters.Add(new Dragon());
                monsters.Add(new Dragon());
                nextScene = new DungeonScene(monsters);
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