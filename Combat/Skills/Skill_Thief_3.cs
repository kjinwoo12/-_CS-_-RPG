using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;

public class Skill_Thief_3 : Skill
{
    public Skill_Thief_3(Character owner)
        : base(owner, "울어라 지옥 참마도", "여러명의 적에게 데미지를 줍니다. 자신도 일부 데미지를 받습니다")
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
            attackOrder.damage = (int)(attackOrder.damage * 2.5f);
            DefenseOrderInfo defenseOrder = target.CreateDefenseOrder(attackOrder);
            target.health -= defenseOrder.actualDamage;
            Console.WriteLine($"{target.name}에게 {skillName}을(를) 사용합니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"{target.name}이(가) {defenseOrder.actualDamage}의 데미지를 받았습니다.");
            Thread.Sleep(1000);
            //# Todo : 데미지 얼마나 줬는지 표시하기
        }
        Console.WriteLine();
        Console.WriteLine($"다신 꺼내지 않으려 했는데... {skillName}!");
        Thread.Sleep(2000);
        int selfDamage = (int)(owner.stats.maxHealth * 0.1f); // 자신에게 주는 데미지(예: 최대 체력의 10%)
        owner.health -= selfDamage; // 자신의 체력에서 데미지 감소
        Console.WriteLine($"{owner.name}이(가) {selfDamage}의 데미지를 받았습니다.");

    }

    public override List<Character> SelectTargetsFrom(List<Character> targets)
    {
        return ParseValidTargetCandidatesFrom(targets);
    }
}