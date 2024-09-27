using System;
public class PlayerInfoScene : IScene
{
    public void OnShow()
    {
        int boxWidth = 25; // 전체 박스 너비
        int contentWidth = boxWidth - 2; // 내용이 들어갈 너비 (테두리 제외)
        int boxHeight = 5; // 박스의 높이


        PlayerCharacter playerCharacter = GameManager.instance.playerCharacter;
        PlayerState playerState = GameManager.instance.playerState;

        Console.WriteLine("┌──────────────────────────┐");
        Console.WriteLine("│                          │");
        Console.WriteLine("│          상태 창         │");
        Console.WriteLine("│                          │");
        Console.WriteLine("└──────────────────────────┘");

        Console.WriteLine("│ 영웅의 정보가 표시됩니다 │");


        Console.WriteLine("┌──────────────────────────┐");
        Console.Write("│");
        // 이름과 직업
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"     [ {playerCharacter.name} ] ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write($"- {playerCharacter.jobName}".PadRight(contentWidth - 12));
        Console.ResetColor();
        Console.WriteLine("│");

        // 레벨
        Console.Write("│");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"LV. {playerCharacter.level} ({playerCharacter.currentExp} / {playerCharacter.maxExp})".PadRight(contentWidth + 3));
        Console.ResetColor();
        Console.WriteLine("│");

        // 공격력
        Console.Write("│");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"공격력: {playerCharacter.stats.minAttack} ~ {playerCharacter.stats.maxAttack}     ".PadRight(contentWidth));
        Console.ResetColor();
        Console.WriteLine("│");

        // 방어력
        Console.Write("│"); Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"방어력: {playerCharacter.stats.minArmor} ~ {playerCharacter.stats.maxArmor}       ".PadRight(contentWidth));
        Console.ResetColor();
        Console.WriteLine("│");

        // 체력
        Console.Write("│"); Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"체력  : {playerCharacter.health}/{playerCharacter.stats.maxHealth}     ".PadRight(contentWidth + 1));
        Console.ResetColor();
        Console.WriteLine("│");

        // 골드
        Console.ResetColor();
        Console.Write("│");
        Console.Write($"골드  : {playerState.gold} G      ".PadRight(contentWidth + 1));
        Console.WriteLine("│");

        Console.WriteLine("└──────────────────────────┘");

        Console.WriteLine("\n[아무키]를 눌러 돌아가기");

        Console.ReadKey(true);
    }

    public IScene GetNextScene()
    {
        return new SpartaTownScene();
    }
}