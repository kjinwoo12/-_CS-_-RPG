using System;
public interface IConsumableItem : IItem
{
    void OnUsed(Character character);
}