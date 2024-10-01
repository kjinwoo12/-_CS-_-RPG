using System;

public class EarlVampire : Monster
{
    public EarlVampire()
        : this("뱀파이어 백작")
    {
    }
    public EarlVampire(string name)
        : base(name, new CharacterStats(150, 15, 25, 10, 15, 7, 10, 0.15f, 0.15f))
    {
        rewardGold = 700;
        rewardExp = 15;
        Random rnd = new Random();

        if (rnd.Next(0, 10) < 2)
        {
            rewardItems.Add(new HealthPotion());
        }

        if (rnd.Next(0, 10) < 2)
        {
            rewardItems.Add(new MagicArmor());
        }

        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 10);
        monsterAiComponent.AddActionWeight(new AiAction_AttackThree(this), 7);
        monsterAiComponent.AddActionWeight(new AiAction_HealAll(this), 2);
    }
}