public class PaperArmor : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(0, -1, 0, 1, 1);

    public string name => "종이 갑옷";

    public string description => "공격력(-1, 0) 방어력(+1, +1) | 아이들이 전쟁놀이 할 때 입었던 신문지 갑옷이다.";

    public string slotName => "갑옷";
}