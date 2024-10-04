using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;

public class Skill_Thief_3 : Skill
{
    public Skill_Thief_3(Character owner)
        : base(owner, "지옥 참마도", "모든 적에게 데미지를 줍니다. 자신도 일부 데미지를 받습니다")
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
            Console.WriteLine($"{target.name}이(가) {defenseOrder.actualDamage}의 데미지를 받았습니다.");
            Thread.Sleep(1000);
            //# Todo : 데미지 얼마나 줬는지 표시하기
        }
        Console.WriteLine();
        Console.WriteLine($"다시는 안뽑기로 했는데... 울어라, {skillName}!");
        Thread.Sleep(2000);
        int selfDamage = (int)(owner.stats.maxHealth * 0.1f);
        owner.health -= selfDamage;
        Console.WriteLine($"{owner.name}이(가) {selfDamage}의 데미지를 받았습니다.");
        Thread.Sleep(1000);

    }

    public override List<Character> SelectTargetsFrom(List<Character> targets)
    {
        return ParseValidTargetCandidatesFrom(targets);
    }
}