using System;
using System.Threading;

public class BigStone : IConsumableItem
{
    public string name => "짱돌    ";
    public string description => "적의 체력 -10";

    public void OnUsed(Character target)
    {
        Console.WriteLine("짱돌을 사용합니다. 적의 체력을 -10 감소시킵니다.");

        target.health -= 10;

        Thread.Sleep(1000);
    }
}