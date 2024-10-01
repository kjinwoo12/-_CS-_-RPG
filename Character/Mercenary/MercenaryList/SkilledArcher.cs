using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 internal class SkilledArcher :  Mercenary
{
    public SkilledArcher()
        : this("숙련된 궁수")
    {
    }

    public SkilledArcher(string name)
        : base(name, new CharacterStats(200, 23, 30, 13, 15, 20, 25, 0.35f, 0.3f))
    {
        level = 7;
        jobName = "아쳐";
        price = 100;
        description = "오랜 시간의 수련으로 숙련된 궁수이다.";
    }
}
