public class Warrior : PlayerCharacter
{
    public Warrior(string name)
        : base(name, new CharacterStats(200, 5, 10, 8, 16, 3, 7, 0.15f, 0.1f))
    {
        jobName = "워리어";

        AddSkill(new Skill_LionSong(this));
    }
}
