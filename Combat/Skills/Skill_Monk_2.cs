using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;


public class Skill_Monk_2 : Skill
{
    public Skill_Monk_2(Character owner)
        : base(owner, "강해져서 돌아와라", "한 명의 적을 치유합니다.")
    {
        // 우리편을 대상으로 하는게 나름 만져보고 있는데 잘 안되고 있네요....ㅜㅜ
    }

    public override bool IsValidFor(Character target)
    {
        if (target.isDead || target.GetType() == owner.GetType() || target.health == target.stats.maxHealth)
        {
            return false;
        }
        return true;
    }

    public override void OnUse(List<Character> targets)
    {
        foreach (Character target in targets)
        {
            int healAmount = (int)(owner.stats.maxHealth * 0.2f); // 최대 체력의 20% 회복
            target.health = Math.Min(target.stats.maxHealth, target.health + healAmount);
            Console.WriteLine($"{target.name}에게 {healAmount}만큼 치유했습니다.");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine($"아직 나약하군...  {skillName}!");
            Thread.Sleep(2000);
        }
    }

    public override List<Character> SelectTargetsFrom(List<Character> targets)
    {
        List<Character> validTargets = ParseValidTargetCandidatesFrom(targets);

        if (validTargets.Count == 0)
        {
            Console.WriteLine("선택할 수 있는 타겟이 없습니다.");
            return null;
        }
        int selectedTargetIndex = 0;
        int minCursorTop = Console.CursorTop;

        for (int i = 0; i < validTargets.Count; i++)
        {
            Console.WriteLine($"- {validTargets[i].name}");
        }

        while (true)
        {
            Console.SetCursorPosition(0, minCursorTop + selectedTargetIndex);
            Console.Write("*");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                Character selectedTarget = validTargets[selectedTargetIndex];
                Console.SetCursorPosition(0, minCursorTop + validTargets.Count);
                return new List<Character> { selectedTarget };
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow && selectedTargetIndex > 0)
            {
                Console.SetCursorPosition(0, minCursorTop + selectedTargetIndex);
                Console.Write("-");
                selectedTargetIndex--;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow && selectedTargetIndex < validTargets.Count - 1)
            {
                Console.SetCursorPosition(0, minCursorTop + selectedTargetIndex);
                Console.Write("-");
                selectedTargetIndex++;
            }

            for (int i = 0; i < validTargets.Count; i++)
            {
                if (i == selectedTargetIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(0, minCursorTop + i);
                    Console.Write($"* {validTargets[i].name}");
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(0, minCursorTop + i);
                    Console.Write($"- {validTargets[i].name}  ");
                }
            }
        }
    }
}

