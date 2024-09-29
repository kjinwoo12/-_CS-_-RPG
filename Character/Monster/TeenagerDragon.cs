using System;

public class TeenagerDragon : Monster
{
    public TeenagerDragon()
        : base("청소년 드래곤", new CharacterStats(500, 50, 70, 45, 55, 13, 20, 20))
    {
        rewardGold = 6000;
        rewardExp = 45;

        Random rnd = new Random();

        if (rnd.Next(0, 100) < 1)
        {
            rewardItems.Add(new DragonArmor());
        }

        if (rnd.Next(0, 100) < 11)
        {
            rewardItems.Add(new StrengthPotion());
        }
    }
}