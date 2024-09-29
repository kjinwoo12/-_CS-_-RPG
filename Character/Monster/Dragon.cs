using System;

public class Dragon : Monster
{
    public Dragon()
        : this("드래곤")
    {
    }

    public Dragon(string name)
        : base(name, new CharacterStats(200, 20, 40, 15, 25))
    {
        rewardGold = 5000;
        rewardExp = 15;

        Random rnd = new Random();

        if (rnd.Next(0, 100) < 1)
        {
            rewardItems.Add(new DragonArmor());
        }

        if (rnd.Next(0, 100) < 1)
        {
            rewardItems.Add(new StrengthPotion());
        }
    }
}