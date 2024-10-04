using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class SkilledThief: Mercenary
{
    public SkilledThief()
        : this("숙련된 암살자")
    {
    }

    public SkilledThief(string name)
        : base(name, new CharacterStats(170, 20, 39, 8, 10, 24, 30, 0.4f, 0.4f))
    {
        level = 7;
        jobName = "시프";
        price = 100;
        description = "오랜 시간의 수련으로 숙련된 암살자다.";

        AddSkill(new Skill_Thief_1(this));
        AddSkill(new Skill_Thief_2(this));
        AddSkill(new Skill_Thief_3(this));
    }
}
