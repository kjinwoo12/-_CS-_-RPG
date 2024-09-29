public class TrashSwordToy : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(0, -1, 2, -1, -1);

    public string name => "쓰레기 검";

    public string description => "공격력(-1, +2) 방어력(-1, -1) | 쓰레기통에서 주운 장난감이다. 만만해보이는 효과가 있다.";

    public string slotName => "무기";
}