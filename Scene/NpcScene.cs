using System;
using System.Threading;

public class NpcScene : IScene

{
    string[] scripts = new string[]
    {
        "나          : 저기... 드래곤 둥지에 다녀오셨다고 들었는데 혹시 용사님만의 비법을 알 수 있을까요?",
        "김록기 용사가 뒤를 돌아본다.",
        "김록기 용사 : 흠... 소문이 빠르군요.",
        "김록기 용사 : 오늘 기분이 좋으니 특별히 알려드리겠습니다.",
        "나          : !!!",
        "김록기 용사 : (속삭이며) 로.끼.비.키",
        "나          : 네??",
        "김록기 용사 : 전 항상 전투 전에 로끼비키를 외치고 들어갑니다... 강해지고 싶다면 외치십쇼.",
        "나          : (작은 목소리로) 로...끼비키...",
        "김록기 용사 : 더 크게!!!!!!!!!",
        "나          : 로끼비...키!!!",
        "김록기 용사 : 더 크게.....!!!!!",
        "나          : 로끼비키!!!!!!!!!!!!!!",
        "김록기 용사의 혹독한 훈련은 다음 날 아침까지 이어졌다는 소문이 있다...",
        ""
    };

    string[] chnpc = new string[]
    {
        "주점에서 나와 비틀거리고 있는 마법사 찬형을 발견한다.",
        "나            : 찬형님 여기 계셨네요! ",
        "마법사 박찬형 : 중얼중얼 중얼중얼",
        "나            : 찬형님... 괜찮으세요?",
        "마법사 박찬형 : (머리를 휘저으며) 아니야!!!!! 아니야!!!!!!",
        "이내 바닥에 쓰러지고 만다.",
        "나            : 찬형님!!!!!!!",
        "마법사 박찬형 : (마지막 힘을 쥐어 짜내며) 분명 치어리더라고 했는데... 분명히 그랬는ㄷ...",
        "나            : 네?? 찬형님 정신 좀 차려보세요!!!!",
        "나는 그 말을 마지막으로 완전히 정신을 잃은 찬형님을 방으로 옮겼다.",
        "나            : 휴... 이게 무슨 일이람... 주점에 대체 뭐가 있는거야?",
        ""
    };

    string[] hwnpc = new string[]
    {
        "주점에서 웅성거리는 소리가 들린다.",
        "나                               : 맥주나 한 잔 마시려고 왔는데 무슨 일이 있나?",
        "배꼽티 치어리딩 복의 힐러 임현우 : 용사님들!!!!!! 힘내세요!!!!! 뮤직 큐!!!!!",
        "어디선가 꿈빛 파티시엘 노래가 흘러나온다...",
        "배꼽티 치어리딩 복의 힐러 임현우 : (동굴목소리로) 포근포근 달콤해 둥글둥글 부푸는 마음~",
        "나는 맥주를 들고 넋이 나간 채로 현우 앞에 멈췄다",
        "배꼽티 치어리딩 복의 힐러 임현우 : 어? 용사님 맥주 드시는구나! 제가 더 맛있게 만들어 드릴게요!",
        "배꼽티 치어리딩 복의 힐러 임현우 : 오이시쿠 나레~ 오이시쿠 나레~ 모에 모에 큥!",
        "쿵",
        "나는 충격에 맥주를 떨어트리고 정신없이 방으로 돌아왔다.",
        ""
    };

    string[] msnpc = new string[]
    {
        "아처 조민솔 : (술에 잔뜩 취한 채로) 고민 좀 들어주실 수 있나요...?",
        "나          : 당연하죠! 같은 용사끼리 서로 돕고 사는 거 아니겠어요?",
        "아처 조민솔 : (울먹이며) 감사합니다... 제가 드래곤을 잡을 수가 없어요...",
        "아처 조민솔 : 한 가정을 파괴하는 기분이 들어요... 저는... 용사가 될 수 없나봐요...",
        "나          : 민솔님! 너무 슬퍼하지 마세요. 깊게 생각하지마시고 가족을 지킨다 생각하고 전투에 임하는 건 어떨까요?",
        "아처 조민솔 : 감사합니다... 딸꾹 근데 제가 고민이 있는데 딸꾹 제가 드래곤을 잡을 수가 없어요...",
        "나            : ...",
        "그렇다. 아처 조민솔은 이 여관 주점의 유명한 주정뱅이였다.",
        ""
    };

    string[] jwnpc = new string[]
    {
        "전사 김진우 : 안녕하세요. 제가 이번에 책을 하나 냈는데요. 후회 안 합니다. 하나 구매해주시겠어요?",
        "나            : 음... 어... 한 권 주세요. ",
        "전사 김진우 : 감사합니다!!!!! 가격은 5000G만 주세요. 첫 고객이셔서 할인해드릴게요! ",
        "책에는 이대로만 하면 내가 이세계 전설의 전사?!라고 적혀있었다.",
        "나            : 비싼 돈 주고 샀으니까 열심히 읽어야지... 지금 한 번 봐야겠네.",
        "제 1장 칼 꺼내기",
        "제 2장 몬스터 때리기",
        "제 3장 칼 집어넣기",
        "끝",
        "나            : 뭐야 끝이야??? 저기요 용사님 이거 뭔가 잘못된 것 같ㅇ...",
        "전사 김진우는 흔적도 없이 사라진 후였다.",
        ""
    };
    
    void WaitForSpacebar()
    {
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                break;
            }
        }
    }

    

   public void OnShow()
    {
        Random rnd = new Random();
        int randomNumber = rnd.Next(1, 6);
        GameManager.instance.playerState.questChecker.unlockNpc(randomNumber);

        if (randomNumber == 1)
        {

            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("스페이스바");
            Console.ResetColor();
            Console.Write("]");
            Console.WriteLine("를 눌러 다음 대화로 넘어가세요...");

            for (int i = 0; i < scripts.Length; i++)
            {
                WaitForSpacebar();
                Console.Write(scripts[i]);
                Console.WriteLine();
            }
            
        }
        else if (randomNumber == 2)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("스페이스바");
            Console.ResetColor();
            Console.Write("]");
            Console.WriteLine("를 눌러 다음 대화로 넘어가세요...");

            for (int i = 0; i < chnpc.Length; i++)
            {
                WaitForSpacebar();
                Console.Write(chnpc[i]);
                Console.WriteLine();
            }


        }
        else if (randomNumber == 3)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("스페이스바");
            Console.ResetColor();
            Console.Write("]");
            Console.WriteLine("를 눌러 다음 대화로 넘어가세요...");

            for (int i = 0; i < hwnpc.Length; i++)
            {
                WaitForSpacebar();
                Console.Write(hwnpc[i]);
                Console.WriteLine();
            }

        }
        else if (randomNumber == 4)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("스페이스바");
            Console.ResetColor();
            Console.Write("]");
            Console.WriteLine("를 눌러 다음 대화로 넘어가세요...");

            for (int i = 0; i < msnpc.Length; i++)
            {
                WaitForSpacebar();
                Console.Write(msnpc[i]);
                Console.WriteLine();
            }

        }
        else if (randomNumber == 5)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("스페이스바");
            Console.ResetColor();
            Console.Write("]");
            Console.WriteLine("를 눌러 다음 대화로 넘어가세요...");

            for (int i = 0; i < jwnpc.Length; i++)
            {
                WaitForSpacebar();
                Console.Write(jwnpc[i]);
                Console.WriteLine();
            }

        }
        WaitForSpacebar();

    }

    public IScene GetNextScene()
    {
        return new HotelScene();
    }
}
