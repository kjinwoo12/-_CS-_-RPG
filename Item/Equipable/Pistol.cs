public class Pistol : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(-10, -3, 6, 0, 0, 0, 0, 0.0f, 0.0f);

    public string name => "권총\t";

    public string description => "최대체력(-10) 공격력(-3, +6) | 이세계에서 건너온 무기. 총알은 없다. 그럼 던지나?";

    public string slotName => "무기";
}