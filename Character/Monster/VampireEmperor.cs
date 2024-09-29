using System;

public class VampireEmperor : Monster
{
    public VampireEmperor()
        : base("뱀파이어 황제", new CharacterStats(200, 20, 30, 15, 20))
    {
        rewardGold = 1000;
        rewardExp = 18;
        Random rnd = new Random();

        if (rnd.Next(0, 10) < 1)
        {
            rewardItems.Add(new LongSword());
        }

        if (rnd.Next(0, 10) < 1)
        {
            rewardItems.Add(new MagicArmor());
        }
    }
}