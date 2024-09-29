using System;

public class EliteGoblin : Monster
{
    public EliteGoblin()
        : base("엘리트 고블린", new CharacterStats(70, 7, 12, 2, 5, 3, 7, 8))
    {
        rewardGold = 55;
        rewardExp = 7;
        Random rnd = new Random();

        if (rnd.Next(0, 10) < 3)
        {
            rewardItems.Add(new WoodStick());
        }

        if (rnd.Next(0, 10) < 2)
        {
            rewardItems.Add(new TrashSwordToy());
        }

        if (rnd.Next(0, 10) < 2)
        {
            rewardItems.Add(new PaperArmor());
        }
    }
}