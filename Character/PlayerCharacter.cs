using System;

public class PlayerCharacter : Character
{
    public string jobName { get; set; }

    public int maxExp { get; private set; } = 10;
    public int currentExp { get; set; } = 0;
    public PlayerCharacter(string name, CharacterStats stats)
        : base(name, stats)
    {
    }

    public void ConsumeItem(IConsumableItem item)
    {
        item.OnUsed(this);
    }

    public void AddExp(int exp)
    {
        currentExp += exp;
        if(maxExp <= currentExp)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level += currentExp / maxExp;
        currentExp = currentExp % maxExp;

        originalStats += levelUpStats;

        if (level == 2)
        {
            maxExp = 35;
        }
        else if (level == 3)
        {
            maxExp = 65;
        }
        else if (level == 4)
        {
            maxExp = 100;
        }
        else if (level == 5)
        {
            maxExp = 2100000000;
        }
        else if (5 < level)
        {
            Console.WriteLine("이걸 올리셨다구요? 정말 대단하십니다.... 능력치는 올려 드리겠습니다...");
            Console.WriteLine("그래도 만렙은 5렙입니다...");
            level = 5;
        }
        else
        {
            Console.WriteLine("버그 발생");
        }
    }
}