using System;

public class Goblin : Monster
{
    public Goblin()
        : this("고블린")
    {
    }

    public Goblin(string name)
        : base(name, new CharacterStats(50, 5, 10, 0, 3, 0, 3, 0.05f, 0.05f))
    {
        rewardGold = 50;
        rewardExp = 5;
        Random rnd = new Random();

        if(rnd.Next(0, 10) < 3)
        {
            rewardItems.Add(new WoodStick());
        }
        
        if(rnd.Next(0, 10) < 2)
        {
            rewardItems.Add(new TrashSwordToy());
        }

        if(rnd.Next(0, 10) < 1)
        {
            rewardItems.Add(new PaperArmor());
        }

        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 4);
        monsterAiComponent.AddActionWeight(new AiAction_AttackThree(this), 2);
        monsterAiComponent.AddActionWeight(new AiAction_HealOne(this), 2);
    }
}