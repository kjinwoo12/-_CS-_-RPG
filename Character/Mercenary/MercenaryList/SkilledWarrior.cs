using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class SkilledWarrior : Mercenary
{
    public SkilledWarrior()
        : this("숙련된 전사")
    {
    }

    public SkilledWarrior(string name)
        : base(name, new CharacterStats(300, 12, 17, 28, 35, 14, 18, 0.1f, 0.2f))
    {
        level = 7;
        jobName = "워리어";
        price = 100;
        description = "오랜 시간의 수련으로 숙련된 전사다.";
    }
}
