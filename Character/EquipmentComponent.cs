using System;
using System.Collections.Generic;

public class EquipmentComponent
{
    public Dictionary<string, IEquipableItem> equipSlot = new Dictionary<string, IEquipableItem>();

    public delegate void OnEquipEvent(IEquipableItem equip);
    public event OnEquipEvent OnEquipDelegate;

    public delegate void OnUnequipEvent(IEquipableItem equip);
    public event OnUnequipEvent OnUnequipDelegate;

    public void Equip(IEquipableItem equip)
    {
        if (equipSlot.ContainsKey(equip.slotName) && equipSlot[equip.slotName] != null)
        {
            Unequip(equip.slotName);
        }

        equipSlot.Add(equip.slotName, equip);
        OnEquipDelegate?.Invoke(equip);
        return;
    }

    public IEquipableItem Unequip(string slotName)
    {
        if(!equipSlot.ContainsKey(slotName))
        {
            return null;
        }

        IEquipableItem removedItem = equipSlot[slotName];
        if(!equipSlot.Remove(slotName))
        {
            return null;
        }
        OnUnequipDelegate?.Invoke(removedItem);
        return removedItem;
    }

    public bool IsEquippedItem(IEquipableItem equip)
    {
        return equipSlot.ContainsValue(equip);
    }
}