using System;
using System.Collections.Generic;
using System.Threading;


// 스킬을 관리하는 클래스
public abstract class Skill : TargetingValidator
{
    public Character owner { get; private set; }
    public string skillName { get; set; }
    public string skillDescription { get; set; }

    public Skill(Character owner, string name, string description)
    {
        this.owner = owner;
        skillName = name;
        skillDescription = description;
    }

    public abstract void OnUse(List<Character> character);
}