using System.Collections.Generic;

public class Monster : Character
{
    public int rewardGold { get; protected set; } = 0;
    public List<IItem> rewardItems { get; protected set; } = new List<IItem>();

    public int rewardExp { get; protected set; } = 5;
    public Monster(string name, CharacterStats stats)
        : base(name, stats)
    {
    }
}