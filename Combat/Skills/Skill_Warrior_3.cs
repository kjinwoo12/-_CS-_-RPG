using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;

public class Skill_Warrior_3 : Skill
{
    public Skill_Warrior_3(Character owner)
        : base(owner, "흑승 빅 드래곤 회오리치기((黒縄・大龍巻)", "여러명의 적에게 적지않은 데미지를 줍니다.")
    {
    }

    public override bool IsValidFor(Character target)
    {
        if (target.isDead || owner.GetType() == target.GetType())
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
            //# Todo : 데미지 얼마나 줬는지 표시하기
        }
        Console.WriteLine();
        Console.WriteLine($"삼도류... {skillName}!");
        Thread.Sleep(2000);

    }

    public override List<Character> SelectTargetsFrom(List<Character> targets)
    {
        return ParseValidTargetCandidatesFrom(targets);
    }
}