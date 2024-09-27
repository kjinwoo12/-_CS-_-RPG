using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Thief : PlayerCharacter
{
    public Thief(string name)
        : base(name, new CharacterStats(100, 6, 18, 1, 2, 15))
    {
        jobName = "시프";
    }
}
