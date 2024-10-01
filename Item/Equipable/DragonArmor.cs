public class DragonArmor : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(50, 0, 0, 5, 5, 0, 0, 0.0f, 0.0f);

    public string name => "드래곤 갑옷";

    public string description => "최대체력(+50) 방어력(+5, +5) | 드래곤이 세상에 어디있어? 당연히 인조 가죽이지.";

    public string slotName => "갑옷";
}