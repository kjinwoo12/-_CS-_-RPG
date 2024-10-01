using System;

public class WizardGoblin : Monster
{
    public WizardGoblin()
        : this("마법사 고블린")
    {
    }

    public WizardGoblin(string name)
        : base (name, new CharacterStats(80, 8, 13, 3, 6, 2, 5, 0.1f, 0.1f))
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

        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 2);
        monsterAiComponent.AddActionWeight(new AiAction_AttackThree(this), 7);
        monsterAiComponent.AddActionWeight(new AiAction_HealAll(this), 12);
    }
}
  

