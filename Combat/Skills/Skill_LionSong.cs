using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;

public class Skill_LionSong : Skill
{
    public Skill_LionSong(Character owner)
        : base(owner, "사자의 노래(獅子歌歌)", "한 명의 적을 강력하게 공격합니다.")
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
            attackOrder.damage = (int)(attackOrder.damage * 1.2);
            DefenseOrderInfo defenseOrder = target.CreateDefenseOrder(attackOrder);
            target.health -= defenseOrder.actualDamage;
            Console.WriteLine($"{target.name}에게 {skillName}을(를) 사용합니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"일도류 발도술... {skillName}!");
            Thread.Sleep(1000);
            //# Todo : 데미지 얼마나 줬는지 표시하기
        }

    }

    public override List<Character> SelectTargetsFrom(List<Character> targets)
    {
        List<Character> result = ParseValidTargetCandidatesFrom(targets);
        if (result.Count < 0)
        {
            return null;
        }

        Random rnd = new Random();
        Character perfactTarget = result[rnd.Next(0, result.Count)];
        result.Clear();
        result.Add(perfactTarget);
        return result;
    }
}