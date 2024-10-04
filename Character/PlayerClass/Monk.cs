using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Monk : PlayerCharacter
{
    public Monk(string name)
        : base(name, new CharacterStats(150, 3, 6, 7, 14, 4, 9, 0.15f, 0.12f))
    {
        jobName = "몽크";

        AddSkill(new Skill_Monk_1(this));
        AddSkill(new Skill_Monk_2(this));
        AddSkill(new Skill_Monk_3(this));
    }
}
