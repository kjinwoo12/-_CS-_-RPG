public class Mercenary : PlayerCharacter
{
    public string jobName { get; set; } = "용병";

    public int price { get; set; } = 0;

    public string description { get; set; }

    public Mercenary(string name, CharacterStats stats)
        : base(name, stats)
    {
        this.maxExp = 0;
    }
}