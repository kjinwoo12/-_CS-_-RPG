using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Archer : PlayerCharacter
{
    public Archer(string name)
        : base(name, new CharacterStats(130, 7, 14, 3, 5, 6, 13, 0.15f))
    {
        jobName = "아쳐";
    }
}
