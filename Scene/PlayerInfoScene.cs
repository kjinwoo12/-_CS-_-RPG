using ConsoleApp1;
using System;
using System.Security.Cryptography;
public class PlayerInfoScene : IScene
{
    public void OnShow()
    {
        PlayerCharacter playerCharacter = GameManager.instance.playerCharacter;
        PlayerState playerState = GameManager.instance.playerState;

        // 각 텍스트의 최대 길이를 계산
        string[] lines = new string[]
          {
            $"[ {playerCharacter.name} ] - {playerCharacter.jobName}",
            $"LV. {playerCharacter.level} ({playerCharacter.currentExp} / {playerCharacter.maxExp})",
            $"공격력: {playerCharacter.stats.minAttack} ~ {playerCharacter.stats.maxAttack}",
            $"방어력: {playerCharacter.stats.minArmor} ~ {playerCharacter.stats.maxArmor}",
            $"체력  : {playerCharacter.health}/{playerCharacter.stats.maxHealth}",
            $"골드  : {playerState.gold} G"
          };

        // 상태창 화면 확인 글
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"[상태 창]");
        Console.WriteLine();
        Console.WriteLine();

        // 상자 그리기
        BoxMaker.Draw(48, 8, 6, 3, ConsoleColor.Red);

        for (int i = 0; i < lines.Length; i++)
        {
            ConsoleColor textColor = i switch
            {
                0 => ConsoleColor.Yellow,   // 이름과 직업은 노란색
                1 => ConsoleColor.Yellow,   // 레벨은 노란색
                2 => ConsoleColor.Red,      // 공격력은 빨간색
                3 => ConsoleColor.Blue,     // 방어력은 파란색
                4 => ConsoleColor.Green,    // 체력은 초록색
                5 => ConsoleColor.Gray,     // 골드는 회색
                _ => ConsoleColor.White,    // 기본 색상
            };
            PrintColoredText(lines[i], 8, 4 + i, textColor);
        }



        Console.SetCursorPosition(0, 15);
        Console.WriteLine("\n[아무키]를 눌러 돌아가기");

        Console.ReadKey(true);
    }

    // 텍스트를 색상과 함께 출력
    private void PrintColoredText(string text, int x, int y, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y); // 출력할 커서 위치 설정
        Console.ForegroundColor = color; // 텍스트 색상 설정
        Console.Write(text);             // 텍스트 출력
        Console.ResetColor();            // 기본 색상으로 복원
    }

    public IScene GetNextScene()
    {
        return new SpartaTownScene();
    }
}