using System;
using System.Threading;

public class StrengthPotion : IConsumableItem
{
    public string name => "공격력 포션";
    public string description => "영구적으로 최소, 최대 공격력 +1";

    public void OnUsed(Character target)
    {
        Console.WriteLine("공격력 포션을 사용합니다. 영구적으로 최소, 최대 공격력이 1 증가합니다.");
        CharacterStats newStats = target.additionalStats;
        newStats.maxAttack += 1;
        newStats.minAttack += 1;
        target.additionalStats = newStats;
        Thread.Sleep(1000);
    }
}