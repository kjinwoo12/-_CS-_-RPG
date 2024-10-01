using System;

public class GoblinKing : Monster
{
    public GoblinKing()
        : this("고블린 왕")
    {
    }

    public GoblinKing(string name)
        : base(name, new CharacterStats(100, 10, 15, 5, 8, 5, 9, 0.15f, 0.15f))
    {
        rewardGold = 100;
        rewardExp = 10;
        Random rnd = new Random();

        if (rnd.Next(0, 10) < 3)
        {
            rewardItems.Add(new WoodStick());
        }

        if (rnd.Next(0, 10) < 2)
        {
            rewardItems.Add(new TrashSwordToy());
        }

        if (rnd.Next(0, 10) < 1)
        {
            rewardItems.Add(new NormalArmor());
        }

        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 10);
        monsterAiComponent.AddActionWeight(new AiAction_AttackThree(this), 6);
        monsterAiComponent.AddActionWeight(new AiAction_HealAll(this), 4);
    }
}