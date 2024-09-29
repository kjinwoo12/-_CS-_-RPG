using System;

public class BaronVampire : Monster
{
    public BaronVampire()
        : base("뱀파이어 남작", new CharacterStats(120, 12, 22, 7, 12, 5, 10, 10))
    {
        rewardGold = 650;
        rewardExp = 12;
        Random rnd = new Random();

        if (rnd.Next(0, 10) < 2)
        {
            rewardItems.Add(new HealthPotion());
        }

        if (rnd.Next(0, 10) < 1)
        {
            rewardItems.Add(new MagicArmor());
        }

        monsterAiComponent.RemoveActions();
        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 10);
        monsterAiComponent.AddActionWeight(new AiAction_AttackThree(this), 4);
        monsterAiComponent.AddActionWeight(new AiAction_HealOne(this), 1);
    }
}