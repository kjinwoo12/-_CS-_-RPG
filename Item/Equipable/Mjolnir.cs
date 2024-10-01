public class Mjolnir : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(-15, 2, 3, 0, 0, 0, 0, 0.0f, 0.0f);

    public string name => "묠니르";

    public string description => "최대 체력(-15) 공격력(+2, +3) | 토르 아저씨네 집에서 빌려온 망치. 어라... 어떻게 들지?";

    public string slotName => "무기";
}