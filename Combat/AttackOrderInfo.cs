public struct AttackOrderInfo
{
    public Character target = null;
    public AttackType attackType;
    public int damage;

    public AttackOrderInfo()
    {
        attackType = AttackType.NORMAL;
        damage = 0;
    }
}