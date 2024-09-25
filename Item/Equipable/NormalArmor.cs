public class NormalArmor : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(-10, 0, 0, 3, 2);

    public string name => "평범한 갑옷";

    public string description => "최대체력(-10) 방어력(+3, +2) | 너무 무거워 체력 단련을 하지 않는 일반인이 입으면 금방 지친다.";

    public string slotName => "갑옷";
}