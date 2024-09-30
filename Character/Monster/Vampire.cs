using System;

public class Vampire : Monster
{
    public Vampire()
        : this("뱀파이어")
    { 
    }

    public Vampire(string name)
        : base(name, new CharacterStats(100, 10, 20, 5, 10, 3, 6, 10))
    {
        rewardGold = 500;
        rewardExp = 10;
        Random rnd = new Random();

        if (rnd.Next(0, 10) < 1)
        {
            rewardItems.Add(new HealthPotion());
        }

        if (rnd.Next(0, 10) < 1)
        {
            rewardItems.Add(new MagicArmor());
        }

        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 8);
        monsterAiComponent.AddActionWeight(new AiAction_AttackThree(this), 3);
        monsterAiComponent.AddActionWeight(new AiAction_HealAll(this), 1);
    }
}