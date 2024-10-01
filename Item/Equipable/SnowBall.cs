public class SnowBall : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(0, 1, 1, 0, 0, 0, 0, 0.0f, 0.0f);

    public string name => "스노우볼";

    public string description => "최대 체력(-2) 공격력(+1, +1) | 누군가 만들어 놓은 눈덩이다. 안에 돌이 보이는 건 기분 탓이겠지?";

    public string slotName => "무기";
}
