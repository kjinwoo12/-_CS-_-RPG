using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;

public class Skill_Monk_1 : Skill
{
    public Skill_Monk_1(Character owner)
        : base(owner, "굳건한 의지", "적을 공격하고 일정 수준의 체력을 회복합니다.")
    {
    }

    public override bool IsValidFor(Character target)
    {
        if (target.isDead || owner.GetType() == target.GetType())  // 예시: 같은 팀 제외
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public override void OnUse(List<Character> targets)
    {
        foreach (Character target in targets)
        {
            AttackOrderInfo attackOrder = owner.CreateAttackOrder(target);
            attackOrder.damage = (int)(attackOrder.damage * 0.8f);
            DefenseOrderInfo defenseOrder = target.CreateDefenseOrder(attackOrder);
            target.health -= defenseOrder.actualDamage;
            Console.WriteLine($"{target.name}에게 {defenseOrder.actualDamage}의 데미지를 주었습니다.");
            Thread.Sleep(1000);

            int healAmount = (int)(owner.stats.maxHealth * 0.1f);
            owner.health = Math.Min(owner.stats.maxHealth, owner.health + healAmount);
            Console.WriteLine($"{owner.name}이(가) {healAmount}만큼 회복했습니다.");
            Thread.Sleep(1000);
            
        }
        Console.WriteLine();
        Console.WriteLine($"기분이 좋구나...  {skillName}!");
        Thread.Sleep(2000);

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