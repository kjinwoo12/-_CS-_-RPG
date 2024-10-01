using System;

public class LesserDragon : Monster
{
    public LesserDragon()
        : this("드래곤")
    {
    }
    public LesserDragon(string name)
        : base(name, new CharacterStats(300, 30, 50, 25, 35, 8, 15, 0.18f, 0.18f))
    {
        rewardGold = 5500;
        rewardExp = 25;

        Random rnd = new Random();

        if (rnd.Next(0, 100) < 6)
        {
            rewardItems.Add(new MagicArmor());
        }

        if (rnd.Next(0, 100) < 11)
        {
            rewardItems.Add(new StrengthPotion());
        }

        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 5);
        monsterAiComponent.AddActionWeight(new AiAction_AttackThree(this), 7);
        monsterAiComponent.AddActionWeight(new AiAction_HealOne(this), 2);
    }
}