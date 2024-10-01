
using System;
using System.Collections.Generic;
public class PlayerState
{
    public int gold { get; set; } = 1500;
    public List<IItem> inventory = new List<IItem>();
    public NpcUnlockChecker questChecker { get; } = new NpcUnlockChecker();

    public bool HasSameItem(IItem item)
    {
        foreach(IItem inventoryItem in inventory)
        {
            if(item.name.Equals(inventoryItem.name))
            {
                return true;
            }
        }
        return false;
    }
}