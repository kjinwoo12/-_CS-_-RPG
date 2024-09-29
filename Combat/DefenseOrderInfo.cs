public struct DefenseOrderInfo
{
    public AttackOrderInfo attackResult = new AttackOrderInfo();
    public int actualDamage;
    public int defenseAmount;

    public DefenseOrderInfo()
    {
        actualDamage = 0;
        defenseAmount = 0;
    }
}