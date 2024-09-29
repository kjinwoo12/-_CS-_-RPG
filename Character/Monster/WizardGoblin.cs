using System;

public class WizardGoblin : Monster
{
    public WizardGoblin()
        : base ("마법사 고블린", new CharacterStats(80, 8, 13, 3, 6, 2, 5, 10))
    {
        rewardGold = 60;
        rewardExp = 8;
        Random rnd = new Random();

        if (rnd.Next(0, 10) < 4)
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
  

