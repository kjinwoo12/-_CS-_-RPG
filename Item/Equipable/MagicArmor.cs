public class MagicArmor : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(0, 0, 0, 4, 8);

    public string name => "마법 갑옷";

    public string description => "방어력(+4, +8) | 남자가 입으면 풀플레이트아머, 여자가 입으면 [검열]이 되는 것이 K-RPG의 전통";

    public string slotName => "갑옷";
}