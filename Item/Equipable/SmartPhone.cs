public class SmartPhone : IEquipableItem
{
    public CharacterStats additionalStats => new CharacterStats(50, 0, 0, 0, 0, 0, 0, 0.0f, 0.0f);

    public string name => "스마트폰";

    public string description => "최대체력(+50) | 유튜브 시청용 스마트폰. 왠지 자신감이 넘친다.";

    public string slotName => "장신구";
}