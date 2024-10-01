using ConsoleApp1;
using System;

class QuestCheckingScene : IScene
{
    public IScene GetNextScene()
    {
        return new SpartaTownScene();
    }

    public void OnShow()
    {
        BoxMaker.Draw(30, 4);
        Console.SetCursorPosition(10, 1);
        Console.Write("퀘스트 목록");
        Console.SetCursorPosition(4, 2);
        Console.Write($"NPC와 대화하기 ({GameManager.instance.playerState.questChecker.getUnlockedCount()}/5)");
        Console.SetCursorPosition(0, 4);
        Console.WriteLine("[스페이스바]를 눌러 돌아가기");
        while(true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if(keyInfo.Key == ConsoleKey.Spacebar)
            {
                break;
            }
        }
    }
}
