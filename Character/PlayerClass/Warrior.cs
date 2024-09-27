using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Warrior : PlayerCharacter
{
    public Warrior(string name)
        : base(name, new CharacterStats(200, 5, 10, 8, 16, 7, 0.15f))
    {
        jobName = "워리어";
    }
}
