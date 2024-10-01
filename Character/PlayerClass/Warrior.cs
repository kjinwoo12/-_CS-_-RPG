using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class Warrior : PlayerCharacter
{
    public Warrior(string name)
        : base(name, new CharacterStats(200, 5, 10, 8, 16, 3, 7, 0.15f))
    {
        jobName = "워리어";

        AddSkill(new Skill("사자의 노래(獅子歌歌)", "일도류 발도술...", 1));
        AddSkill(new Skill("드래곤 회오리치기(龍巻き)", "삼도류....", 3));
        AddSkill(new Skill("108 번뇌봉(煩悩鳳)", "삼도류...", 2));
    }
}
