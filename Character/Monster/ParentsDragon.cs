using System;

public class ParentsDragon : Monster
{
    public ParentsDragon()
        : this("엄빠 드래곤")
    {
    }
    public ParentsDragon(string name)
        : base(name, new CharacterStats(1000, 100, 120, 50, 70, 20, 35, 30))
    {
        rewardGold = 10000;
        rewardExp = 100;

        Random rnd = new Random();

        if (rnd.Next(0, 100) < 16)
        {
            rewardItems.Add(new DragonArmor());
        }

        if (rnd.Next(0, 100) < 11)
        {
            rewardItems.Add(new StrengthPotion());
        }

        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 10);
        monsterAiComponent.AddActionWeight(new AiAction_AttackThree(this), 15);
        monsterAiComponent.AddActionWeight(new AiAction_HealAll(this), 7);
    }
}