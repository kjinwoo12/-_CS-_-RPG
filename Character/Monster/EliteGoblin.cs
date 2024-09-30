using System;

public class EliteGoblin : Monster
{
    public EliteGoblin()
        : this("엘리트 고블린")
    {
    }

    public EliteGoblin(string name)
        : base(name, new CharacterStats(70, 7, 12, 2, 5, 3, 7, 8))
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

        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 7);
        monsterAiComponent.AddActionWeight(new AiAction_AttackThree(this), 3);
        monsterAiComponent.AddActionWeight(new AiAction_HealOne(this), 5);
    }
}