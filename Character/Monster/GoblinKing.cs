using System;

public class GoblinKing : Monster
{
    public GoblinKing()
        : base("고블린 왕", new CharacterStats(100, 10, 15, 5, 8, 5, 9, 15))
    {
        rewardGold = 100;
        rewardExp = 10;
        Random rnd = new Random();

        if (rnd.Next(0, 10) < 3)
        {
            rewardItems.Add(new WoodStick());
        }

        if (rnd.Next(0, 10) < 2)
        {
            rewardItems.Add(new TrashSwordToy());
        }

        if (rnd.Next(0, 10) < 1)
        {
            rewardItems.Add(new NormalArmor());
        }
    }
}