using System;
using System.Threading;

public class Brick : IConsumableItem
{
    public string name => "벽돌    ";
    public string description => "적의 체력 -15";

    public void OnUsed(Character target)
    {
        Console.WriteLine("벽돌을 사용합니다. 적의 체력을 -15 감소시킵니다.");

        target.health -= 15;

        Thread.Sleep(1000);
    }
}