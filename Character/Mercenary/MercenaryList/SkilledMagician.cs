using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class SkilledMagician : Mercenary
{
    public SkilledMagician()
        : this("숙련된 마법사")
    {
    }

    public SkilledMagician(string name)
        : base(name, new CharacterStats(170, 26, 34, 10, 12, 11, 15, 0.2f, 0.25f))
    {
        level = 7;
        jobName = "매지션";
        price = 100;
        description = "오랜 시간의 수련으로 숙련된 마법사다.";

        AddSkill(new Skill_Magician_1(this));
        AddSkill(new Skill_Magician_2(this));
        AddSkill(new Skill_Magician_3(this));
    }
}