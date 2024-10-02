using System;
using System.Threading;

public class BangSnaps : IConsumableItem
{
    public string name => "콩알탄  ";
    public string description => "적의 체력 -5";

    public void OnUsed(Character target)
    {
        Console.WriteLine("콩알탄을 사용합니다. 적의 체력을 -5 감소시킵니다.");

        target.health -= 5;

        Thread.Sleep(1000);
    }
}