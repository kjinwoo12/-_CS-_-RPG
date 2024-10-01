public class Dagger : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(0, 2, 4, 0, 0, 0, 0, 0.0f, 0.0f);

    public string name => "단검\t";

    public string description => "공격력(+2, +4) | 어머 아들! 공부 중이구나? 과일 먹을래?";

    public string slotName => "무기";
}