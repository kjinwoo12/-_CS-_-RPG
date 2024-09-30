using System;

public class Dragon : Monster
{
    public Dragon()
        : this("드래곤 알")
    {
    }

    public Dragon(string name)
        : base(name, new CharacterStats(200, 20, 40, 15, 25, 5, 10, 15))
    {
        rewardGold = 5000;
        rewardExp = 15;

        Random rnd = new Random();

        if (rnd.Next(0, 100) < 31)
        {
            rewardItems.Add(new PaperArmor());
        }

        if (rnd.Next(0, 100) < 1)
        {
            rewardItems.Add(new StrengthPotion());
        }

        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 10);
        monsterAiComponent.AddActionWeight(new AiAction_AttackThree(this), 2);
        monsterAiComponent.AddActionWeight(new AiAction_HealOne(this), 1);
    }
}