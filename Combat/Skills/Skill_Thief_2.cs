using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;

public class Skill_Thief_2 : Skill
{
    public Skill_Thief_2(Character owner)
        : base(owner, "Venomous Dagger", "최대 세명의 적을 강력하게 공격합니다.")
    {
    }

    public override bool IsValidFor(Character target)
    {
        if (target.isDead || (owner is PlayerCharacter && target is PlayerCharacter) || (owner is Monster && target is Monster))
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
            attackOrder.damage = (int)(attackOrder.damage * 1.2f);
            DefenseOrderInfo defenseOrder = target.CreateDefenseOrder(attackOrder);
            target.health -= defenseOrder.actualDamage;
            Console.WriteLine($"{target.name}에게 {skillName}을(를) 사용합니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"{target.name}이(가) {defenseOrder.actualDamage}의 데미지를 받았습니다.");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
        Console.WriteLine($"독은 비겁하지 않아... {skillName}!");
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
        int maxTargetCount = Math.Min(3, validTargets.Count); // 여기서 맞는 적의 수를 표현하면 되겠습니다.
        List<Character> selectedTargets = new List<Character>();

        for (int i = 0; i < validTargets.Count; i++)
        {
            Console.WriteLine($"- {validTargets[i].name}");
        }

        while (selectedTargets.Count < maxTargetCount)
        {
            Console.SetCursorPosition(0, minCursorTop + selectedTargetIndex);
            Console.Write("*");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                Character selectedTarget = validTargets[selectedTargetIndex];
                if (!selectedTargets.Contains(selectedTarget))
                {
                    selectedTargets.Add(selectedTarget);
                    Console.SetCursorPosition(0, minCursorTop + selectedTargetIndex);
                }

                if (selectedTargets.Count >= maxTargetCount)
                {
                    Console.SetCursorPosition(0, minCursorTop + validTargets.Count);
                    return selectedTargets;
                }
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
                if (selectedTargets.Contains(validTargets[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(0, minCursorTop + i);
                    Console.Write($"* {validTargets[i].name}");
                    Console.ResetColor();
                }
                else if (i == selectedTargetIndex)
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

        Console.SetCursorPosition(0, minCursorTop + validTargets.Count);
        return selectedTargets;
    }

}