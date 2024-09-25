using System;

public class PlayerCharacter : Character
{
    public string jobName { get; set; }
    public int maxExp { get; } = 25;
    public int currentExp { get; set; } = 0;
    public PlayerCharacter(string name, CharacterStats stats)
        : base(name, stats)
    {
    }

    public void ConsumeItem(IConsumableItem item)
    {
        item.OnUsed(this);
    }

    public void AddExp(int exp)
    {
        currentExp += exp;
        if(maxExp < currentExp)
        {
            level+=currentExp / maxExp;
            currentExp = currentExp % maxExp;
        }
    }
}