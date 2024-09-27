using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Monk : PlayerCharacter
{
    public Monk(string name)
        : base(name, new CharacterStats(150, 3, 6, 7, 14, 9, 0.15f))
    {
        jobName = "몽크";
    }
}
