using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Mercenary : PlayerCharacter
{
    public string jobName { get; set; } = "없음";

    public int price { get; set; } = 0;

    public string description { get; set; } = "빈 슬롯입니다. 여관에서 용병을 고용해 저장할 수 있습니다.";

    public Mercenary(string name, CharacterStats stats)
        : base(name, stats)
    {
    }
}