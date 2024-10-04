using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


public class Skill_Monk_2 : Skill
{
    public Skill_Monk_2(Character owner)
        : base(owner, "격체전공", "아군 한 명을 치유합니다.")
    {
    }

    public override bool IsValidFor(Character target)
    {
        return target is PlayerCharacter && !target.isDead && target.health < target.stats.maxHealth;
    }

    public override void OnUse(List<Character> targets)
    {
        foreach (Character target in targets)
        {
            int healAmount = (int)(owner.stats.maxHealth * 0.2f); // 최대 체력의 20% 회복
            target.health = Math.Min(target.stats.maxHealth, target.health + healAmount);
            Console.WriteLine($"{target.name}을/를 {healAmount}만큼 치유했습니다.");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine($"영웅은 죽지 않아요...");
            Thread.Sleep(2000);
        }
    }

    public override List<Character> SelectTargetsFrom(List<Character> targets)
    {
        List<Character> validTargets = targets.Where(target => target is PlayerCharacter && !target.isDead && target.health < target.stats.maxHealth).ToList();

        if (validTargets.Count == 0)
        {
            Console.WriteLine("치유할 수 있는 아군이 없습니다.");
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

