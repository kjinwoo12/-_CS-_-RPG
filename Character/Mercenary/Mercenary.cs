using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mercenary : PlayerCharacter
{
    public string jobName { get; set; }

    public int price { get; set; }

    public string description { get; set; }

    public Mercenary(string name, CharacterStats stats)
        : base(name, stats)
    {
    }
}