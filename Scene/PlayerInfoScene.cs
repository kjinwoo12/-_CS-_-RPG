using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public struct DrawInfo
{
    public int width;
    public int height;
    public int cursorX;
    public int cursorY;
    public ConsoleColor borderColor;

    public DrawInfo(int width , int height, int cursorX, int cursorY, ConsoleColor borderColor)
    {
        this.width = width; 
        this.height = height;
        this.cursorX = cursorX;
        this.cursorY = cursorY;
        this.borderColor = borderColor;
    }
}

public class PlayerInfoScene : IScene
{
    public void OnShow()
    {
        PlayerCharacter playerCharacter = GameManager.instance.playerCharacter;
        PlayerState playerState = GameManager.instance.playerState;
        
        DrawInfo playerDrawInfo = new DrawInfo(48, 10, 6, 3, ConsoleColor.Red);
        DrawInfo mercenaryDrawInfo = new DrawInfo(30, 9, 6, 16, ConsoleColor.Blue);

        PrintStats(playerCharacter, playerDrawInfo);
        PrintColoredText($"골드     : {playerState.gold} G", 8, 11, ConsoleColor.DarkYellow);

        Console.SetCursorPosition(0, 15);
        Console.WriteLine("[고용한 용병 목록]");

        SortedDictionary<int, Mercenary> mercenarySlot = GameManager.instance.mercenarySlot;

        foreach (KeyValuePair<int, Mercenary> mercenary in mercenarySlot)
        {
            PrintStats(mercenary.Value, mercenaryDrawInfo);
            mercenaryDrawInfo.cursorX += 30;
            
        }



        Console.SetCursorPosition(0, 25);
        Console.WriteLine("\n[아무키]를 눌러 돌아가기");

        Console.ReadKey(true);
    }

    private void PrintStats(PlayerCharacter character, DrawInfo drawInfo)
    {
        string[] lines = new string[]
          {
            $"[ {character.name} ] - {character.jobName}",
            $"LV. {character.level} ({character.currentExp} / {character.maxExp})",
            $"체력     : {character.health}/{character.stats.maxHealth}",
            $"공격력   : {character.stats.minAttack} ~ {character.stats.maxAttack}",
            $"방어력   : {character.stats.minArmor} ~ {character.stats.maxArmor}",
            $"치명타율 : {(int)(character.stats.criticalRate * 100)}%",
            $"회피율   : {(int)(character.stats.avoidRate* 100f)}%",
          };

        // 상태창 화면 확인 글
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"[상태 창]");
        Console.WriteLine();
        Console.WriteLine();

        // 상자 그리기
        BoxMaker.Draw(drawInfo.width, drawInfo.height, drawInfo.cursorX, drawInfo.cursorY, drawInfo.borderColor);

        for (int i = 0; i < lines.Length; i++)
        {
            ConsoleColor textColor = i switch
            {
                0 => ConsoleColor.Yellow,  // 이름과 직업은 노란색
                1 => ConsoleColor.Yellow,  // 레벨은 노란색
                2 => ConsoleColor.Green,   // 체력은 초록색
                3 => ConsoleColor.Red,     // 공격력은 빨간색
                4 => ConsoleColor.Blue,    // 방어력은 파란색
                5 => ConsoleColor.Magenta, // 치명타율은 자주색
                6 => ConsoleColor.Cyan,    // 회피율은 청록
                _ => ConsoleColor.White,   // 기본 색상
            };
            PrintColoredText(lines[i], drawInfo.cursorX + 2, drawInfo.cursorY + i + 1, textColor);
        }
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