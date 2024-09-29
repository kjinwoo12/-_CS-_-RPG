using System;

public class LesserDragon : Monster
{
    public LesserDragon()
        : base("드래곤", new CharacterStats(300, 30, 50, 25, 35))
    {
        rewardGold = 5500;
        rewardExp = 25;

        Random rnd = new Random();

        if (rnd.Next(0, 100) < 6)
        {
            rewardItems.Add(new MagicArmor());
        }

        if (rnd.Next(0, 100) < 11)
        {
            rewardItems.Add(new StrengthPotion());
        }
    }
}