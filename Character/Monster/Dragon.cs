using System;

public class Dragon : Monster
{
    public Dragon()
        : base("드래곤 알", new CharacterStats(200, 20, 40, 15, 25))
    {
        rewardGold = 5000;
        rewardExp = 15;

        Random rnd = new Random();

        if (rnd.Next(0, 100) < 31)
        {
            rewardItems.Add(new PaperArmor());
        }

        if (rnd.Next(0, 100) < 1)
        {
            rewardItems.Add(new StrengthPotion());
        }
    }
}