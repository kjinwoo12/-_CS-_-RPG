public class Clothes : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(0, 0, 0, 1, 1, 0, 0, 0.0f, 0.0f);

    public string name => "평범한 옷";

    public string description => "방어력(+1, +1) | 속옷이 포함된 평범한 옷 세트다. 그럼 지금까지 옷이 없던 주인공은 벌거벗은";

    public string slotName => "옷";
}