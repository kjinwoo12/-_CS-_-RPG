using System;
using System.Threading;

public class RelaxScene : IScene
{
    public void OnShow()
    {
        if(GameManager.instance.playerState.gold < 500)
        {
            Console.WriteLine("여관 주인 : 여서오세요~");
            Thread.Sleep(700);
            Console.WriteLine("나        : 숙박이요.");
            Thread.Sleep(700);
            Console.WriteLine("여관 주인 : 500 골드 입니다.");
            Thread.Sleep(700);
            Console.WriteLine("나        : 앗... 골드가 모자라다.");
            Thread.Sleep(700);
            Console.WriteLine("여관비 500 G 가 없습니다.");
            Thread.Sleep(700);
            Console.WriteLine("마을로 돌아갑니다.");
        }
        else
        {
            Console.WriteLine("여관 주인 : 여서오세요~");
            Thread.Sleep(700);
            Console.WriteLine("나        : 숙박이요.");
            Thread.Sleep(700);
            Console.WriteLine("여관 주인 : 500 골드 입니다.");
            Thread.Sleep(700);
            Console.WriteLine("나        : 여기요.");
            Thread.Sleep(700);
            Console.WriteLine("여관에서 휴식 즐기는 중");
            GameManager.instance.playerCharacter.health = GameManager.instance.playerCharacter.stats.maxHealth;
            GameManager.instance.playerState.gold -= 500;
        }
        Thread.Sleep(1000);
    }

    public IScene GetNextScene()
    {
        return new SpartaTownScene();
    }
}