using System;
using System.Collections.Generic;

public abstract class Monster : Character
{
    public int rewardGold { get; protected set; } = 0;
    public List<IItem> rewardItems { get; protected set; } = new List<IItem>();
    public MonsterAiComponent monsterAiComponent { get; protected set; }

    public int rewardExp { get; protected set; } = 5;
    public Monster(string name, CharacterStats stats)
        : base(name, stats)
    {
        monsterAiComponent = new MonsterAiComponent();
        monsterAiComponent.AddActionWeight(new AiAction_AttackOne(this), 5);
    }
}
