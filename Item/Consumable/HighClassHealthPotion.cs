using System;
using System.Threading;

public class HighClassHealthPotion : IConsumableItem
{
    public string name => "고급 체력포션";
    public string description => "체력 +100 회복";

    public void OnUsed(Character target)
    {
        Console.WriteLine("고급 체력포션을 사용합니다. 체력을 +100 회복합니다.");

        target.health += 100;

        if (target.health > target.stats.maxHealth)
        {
            target.health = target.stats.maxHealth;

        }

        Thread.Sleep(1000);
    }
}