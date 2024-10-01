public class LeatherArmor : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(10, 0, 0, 1, 2, 0, 0, 0.0f, 0.0f);

    public string name => "가죽 갑옷";

    public string description => "최대 체력(+10) 방어력(+1, +2) | 이태리 장인이 한땀 한땀 만든 가죽 갑옷.";

    public string slotName => "갑옷";
}