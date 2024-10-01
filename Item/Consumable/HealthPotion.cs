using System;
using System.Threading;

public class HealthPotion : IConsumableItem
{
    public string name => "하급 체력포션";
    public string description => "체력 +20 회복";

    public void OnUsed(Character target)
    {
        Console.WriteLine("하급 체력포션을 사용합니다. 체력을 +20 회복합니다.");

        target.health += 20;

        if (target.health > target.stats.maxHealth)
        {
            target.health = target.stats.maxHealth;
            
        }
        
        Thread.Sleep(1000);
    }
}