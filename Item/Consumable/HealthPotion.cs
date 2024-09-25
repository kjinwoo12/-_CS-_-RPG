using System;
using System.Threading;

public class HealthPotion : IConsumableItem
{
    public string name => "체력 포션";
    public string description => "최대체력 +1 증가";

    public void OnUsed(Character target)
    {
        Console.WriteLine("체력 포션을 사용합니다. 최대 체력이 영구적으로 +1 상승합니다.");
        CharacterStats stats = target.additionalStats;
        stats.maxHealth += 1;
        target.additionalStats = stats;
        Thread.Sleep(1000);
    }
}