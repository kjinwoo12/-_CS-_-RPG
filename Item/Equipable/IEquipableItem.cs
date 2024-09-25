using System;
public interface IEquipableItem : IItem
{
    CharacterStats additionalStats { get; }
    string slotName { get; }
}