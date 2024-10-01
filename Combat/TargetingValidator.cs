using System.Collections.Generic;

public abstract class TargetingValidator
{
    public abstract bool IsValidFor(Character Target);

    protected virtual List<Character> ParseValidTargetCandidatesFrom(List<Character> targets)
    {
        List<Character> result = new List<Character>();
        foreach (Character target in targets)
        {
            if (IsValidFor(target))
            {
                result.Add(target);
            }
        }
        return result;
    }
    public abstract List<Character> SelectTargetsFrom(List<Character> targets);
}