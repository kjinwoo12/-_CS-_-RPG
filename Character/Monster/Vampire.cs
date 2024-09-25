using System;

public class Vampire : Monster
{
    public Vampire()
        : base("뱀파이어", new CharacterStats(100, 10, 20, 5, 10))
    {
        rewardGold = 500;
        rewardExp = 10;
        Random rnd = new Random();

        if (rnd.Next(0, 10) < 1)
        {
            rewardItems.Add(new HealthPotion());
        }

        if (rnd.Next(0, 10) < 1)
        {
            rewardItems.Add(new MagicArmor());
        }
    }
}