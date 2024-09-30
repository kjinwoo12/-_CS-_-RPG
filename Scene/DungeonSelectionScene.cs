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
        Console.WriteLine("어떤 곳을 토벌할지 골라주세요.");

        Console.WriteLine("1. 세얼간이 고블린의 숙소");
        Console.WriteLine("2. 고블린 움막");
        Console.WriteLine("3. 고블린 기지");
        Console.WriteLine("4. 뱀파이어 남작의 산책길");
        Console.WriteLine("5. 뱀파이어 대저택");
        Console.WriteLine("6. 뱀파이어 성");
        Console.WriteLine("7. 드래곤 둥지");
        Console.WriteLine("8. 드래곤 숲");
        Console.WriteLine("9. 드래곤 동굴");
        Console.WriteLine("0. 나가기");

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if(keyInfo.KeyChar == '1')
            {
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new Goblin("고블린1"));
                monsters.Add(new Goblin("고블린2"));
                monsters.Add(new Goblin("고블린3"));
                monsters.Add(new EliteGoblin("엘리트 고블린"));
                nextScene = new DungeonScene(monsters);
                break;
            }
            else if (keyInfo.KeyChar == '2')
            {
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new EliteGoblin("엘리트 고블린1"));
                monsters.Add(new EliteGoblin("엘리트 고블린2"));
                monsters.Add(new WizardGoblin("마법사 고블린1"));
                monsters.Add(new WizardGoblin("마법사 고블린2"));
                nextScene = new DungeonScene(monsters);
                break;
            }
            else if (keyInfo.KeyChar == '3')
            {
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new GoblinKing("고블린 킹"));
                monsters.Add(new EliteGoblin("엘리트 고블린"));
                monsters.Add(new WizardGoblin("마법사 고블린"));
                monsters.Add(new Goblin("고블린1"));
                monsters.Add(new Goblin("고블린2"));
                monsters.Add(new Goblin("고블린3"));
                monsters.Add(new Goblin("고블린4"));
                monsters.Add(new Goblin("고블린5"));

                nextScene = new DungeonScene(monsters);
                break;
            }
            else if (keyInfo.KeyChar == '4')
            {
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new Vampire("뱀파이어1"));
                monsters.Add(new Vampire("뱀파이어2"));
                monsters.Add(new Vampire("뱀파이어3"));
                monsters.Add(new BaronVampire("뱀파이어 남작"));
                nextScene = new DungeonScene(monsters);
                break;
            }
            else if (keyInfo.KeyChar == '5')
            {
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new BaronVampire("뱀파이어 남작1"));
                monsters.Add(new BaronVampire("뱀파이어 남작2"));
                monsters.Add(new EarlVampire("뱀파이어 백작1"));
                monsters.Add(new EarlVampire("뱀파이어 백작2"));

                nextScene = new DungeonScene(monsters);
                break;
            }
            else if (keyInfo.KeyChar == '6')
            {
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new VampireEmperor("뱀파이어 황제"));
                monsters.Add(new BaronVampire("뱀파이어 남작"));
                monsters.Add(new EarlVampire("뱀파이어 백작"));
                monsters.Add(new Vampire("뱀파이어1"));
                monsters.Add(new Vampire("뱀파이어2"));
                monsters.Add(new Vampire("뱀파이어3"));
                monsters.Add(new Vampire("뱀파이어4"));
                monsters.Add(new Vampire("뱀파이어5"));

                nextScene = new DungeonScene(monsters);
                break;
            }
            else if (keyInfo.KeyChar == '7')
            {
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new Dragon("드래곤 알1"));
                monsters.Add(new Dragon("드래곤 알2"));
                monsters.Add(new Dragon("드래곤 알3"));
                monsters.Add(new LesserDragon("드래곤"));
                nextScene = new DungeonScene(monsters);
                break;
            }
            else if (keyInfo.KeyChar == '8')
            {
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new LesserDragon("드래곤1"));
                monsters.Add(new LesserDragon("드래곤2"));
                monsters.Add(new TeenagerDragon("청소년 드래곤1"));
                monsters.Add(new TeenagerDragon("청소년 드래곤2"));
                nextScene = new DungeonScene(monsters);
                break;
            }
            else if (keyInfo.KeyChar == '9')
            {
                List<Monster> monsters = new List<Monster>();
                monsters.Add(new ParentsDragon("엄빠 드래곤"));
                monsters.Add(new TeenagerDragon("청소년 드래곤"));
                monsters.Add(new LesserDragon("드래곤"));
                monsters.Add(new Dragon("드래곤 알1"));
                monsters.Add(new Dragon("드래곤 알2"));
                monsters.Add(new Dragon("드래곤 알3"));
                monsters.Add(new Dragon("드래곤 알4"));
                monsters.Add(new Dragon("드래곤 알5"));
                nextScene = new DungeonScene(monsters);
                break;
            }
            else if (keyInfo.KeyChar == '0')
            {
                nextScene = new SpartaTownScene();
                break;
            }
        }
    }
}