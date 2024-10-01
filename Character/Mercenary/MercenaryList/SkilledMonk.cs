using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class SkilledMonk: Mercenary
{
    public SkilledMonk()
        : this("숙련된 수도승")
    {
    }

    public SkilledMonk(string name)
        : base(name, new CharacterStats(230, 15, 18, 20, 27, 16, 22, 0.15f, 0.3f))
    {
        level = 7;
        jobName = "몽크";
        price = 100;
        description = "오랜 시간의 수련으로 숙련된 수도승이다.";
    }
}
