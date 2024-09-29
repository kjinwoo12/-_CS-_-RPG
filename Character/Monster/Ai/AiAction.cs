using System;
using System.Collections.Generic;

public abstract class AiAction
{
    public string actionName { get; private set; }
    protected Monster owner;
    protected AiAction(string actionName, Monster owner)
    {
        this.actionName = actionName;
        this.owner = owner;
    }
    public abstract bool IsValidFor(Character target);

    protected virtual List<Character> ParseValidTargetCandidatesFrom(List<Character> targets)
    {
        List<Character> result = new List<Character>();
        foreach (Character target in targets)
        {
            if(IsValidFor(target))
            {
                result.Add(target);
            }
        }
        return result;
    }

    public abstract List<Character> SelectTargetsFrom(List<Character> targets);
}

public class AiAction_AttackOne : AiAction
{
    public AiAction_AttackOne(Monster owner)
        : base("단일 공격", owner)
    {
    }

    public override bool IsValidFor(Character target)
    {
        if (target.isDead || target is Monster)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public override List<Character> SelectTargetsFrom(List<Character> targets)
    {
        List<Character> result = ParseValidTargetCandidatesFrom(targets);
        Random rnd = new Random();
        Character perfactTarget = null;
        if (rnd.Next(0, 2) < 1)
        { //Parse weak target
            foreach (Character target in result)
            {
                if(perfactTarget == null)
                {
                    perfactTarget = target;
                    continue;
                }

                if (target.health <= owner.stats.minAttack)
                {
                    if(perfactTarget.health < target.health)
                    {
                        perfactTarget = target;
                    }
                    continue;
                }

                if (target.health < perfactTarget.health)
                {
                    perfactTarget = target;
                    continue;
                }
            }
        }
        else
        { //Parse powerful target
            foreach (Character target in result)
            {
                if (perfactTarget == null)
                {
                    perfactTarget = target;
                    continue;
                }

                if (target.stats.maxAttack < perfactTarget.stats.maxAttack)
                {
                    perfactTarget = target;
                    continue;
                }
            }
        }
        result.Clear();
        if (perfactTarget != null)
        {
            result.Add(perfactTarget);
        }
        return result;
    }
}
public class AiAction_AttackThree : AiAction
{
    public AiAction_AttackThree(Monster owner) 
        : base("광역 공격", owner)
    {
    }

    public override List<Character> SelectTargetsFrom(List<Character> targets)
    {
        List<Character> result = ParseValidTargetCandidatesFrom(targets);
        Random rnd = new Random();
        while(result.Count > 3)
        {
            if(rnd.Next(0, 2)<1)
            {
                result.RemoveAt(rnd.Next(0, result.Count));
            }
        }
        return result;
    }

    public override bool IsValidFor(Character target)
    {
        if (target.isDead || target is Monster)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
public class AiAction_HealAll : AiAction
{
    public AiAction_HealAll(Monster owner)
        : base("광역 힐", owner)
    {
    }

    public override List<Character> SelectTargetsFrom(List<Character> targets)
    {
        return ParseValidTargetCandidatesFrom(targets);
    }

    public override bool IsValidFor(Character target)
    {
        if (target.isDead || target is PlayerCharacter || target.health == target.stats.maxHealth)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

public class AiAction_HealOne : AiAction
{
    public AiAction_HealOne(Monster owner)
        : base("단일 힐", owner)
    {
    }

    public override List<Character> SelectTargetsFrom(List<Character> targets)
    {
        List<Character> result = ParseValidTargetCandidatesFrom(targets);

        Character perfactTarget = null;
        foreach (Character target in result)
        {
            if (perfactTarget == null)
            {
                perfactTarget = target;
                continue;
            }

            if (target.health <= owner.stats.minAttack)
            {
                if (perfactTarget.health < target.health)
                {
                    perfactTarget = target;
                }
                continue;
            }

            if (target.health < perfactTarget.health)
            {
                perfactTarget = target;
                continue;
            }
        }
        result.Clear();
        if (perfactTarget != null)
        {
            result.Add(perfactTarget);
        }
        return result;
    }

    public override bool IsValidFor(Character target)
    {
        if (target.isDead || target is PlayerCharacter || target.health == target.stats.maxHealth)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}