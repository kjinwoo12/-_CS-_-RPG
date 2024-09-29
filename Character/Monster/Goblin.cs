using System;

public class Goblin : Monster
{
    public Goblin()
        : this("고블린")
    {
    }

    public Goblin(string name)
        : base(name, new CharacterStats(50, 5, 10, 0, 3))
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
            rewardItems.Add(new TrashSword());
        }

        if(rnd.Next(0, 10) < 1)
        {
            rewardItems.Add(new PaperArmor());
        }
    }
}