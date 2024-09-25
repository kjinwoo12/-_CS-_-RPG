using System;

class Product
{
    Type itemType;
    public IItem defaultItemInstance;
    public int price { get; set; }
    public bool isSoldOut
    {
        get
        {
            return defaultItemInstance is IEquipableItem &&
                    GameManager.instance.playerState.HasSameItem(defaultItemInstance);
        }
    }

    public Product(int price, Type itemType)
    {
        this.price = price;
        this.itemType = itemType;
        this.defaultItemInstance = CreateItemInstance();
    }
    public IItem CreateItemInstance()
    {
        return (IItem)Activator.CreateInstance(itemType);
    }
}