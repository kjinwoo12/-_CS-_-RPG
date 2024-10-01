public class WoodStick : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(0, 1, 1, 0, 0, 0, 0, 0.0f, 0.0f);

    public string name => "나무 막대기";

    public string description => "공격력(+1, +1) | 엑스칼리버 뺨치는 모습의 나무 막대기. 남자의 마음을 울린다.";

    public string slotName => "무기";
}