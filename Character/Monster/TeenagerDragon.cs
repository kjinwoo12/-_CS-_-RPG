using System;

public class TeenagerDragon : Monster
{
    public TeenagerDragon()
        : this("청소년 드래곤")
    {
    }
    public TeenagerDragon(string name)
        : base(name, new CharacterStats(500, 50, 70, 45, 55, 13, 20, 0.2f, 0.2f))
    {
        rewardGold = 6000;
        rewardExp = 45;

        Random rnd = new Random();

        if (rnd.Next(0, 100) < 1)
        {
            rewardItems.Add(new DragonArmor());
        }

        if (rnd.Next(0, 100) < 11)
        {
            rewardItems.Add(new StrengthPotion());
        }

        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 8);
        monsterAiComponent.AddActionWeight(new AiAction_AttackThree(this), 5);
        monsterAiComponent.AddActionWeight(new AiAction_HealOne(this), 1);
    }
}