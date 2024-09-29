using System.Collections.Generic;
using System;

class ProductManager
{
    private static readonly Lazy<ProductManager> lazy = new Lazy<ProductManager>(() => new ProductManager());
    public static ProductManager instance { get { return lazy.Value; } }

    public List<Product> products { get; }
    public Dictionary<string, int> sellingInfo { get; }

    private ProductManager()
    {
        products = new List<Product>();
        sellingInfo = new Dictionary<string, int>();
        //Consumable
        AddProduct(10000, typeof(StrengthPotion));
        AddProduct(1000, typeof(HealthPotion));

        //Weapon
        AddProduct(500, typeof(TrashSwordToy));
        AddProduct(2000, typeof(WoodStick));
        AddProduct(8000, typeof(Dagger));
        AddProduct(32000, typeof(Pistol));
        AddProduct(128000, typeof(LongSword));

        //Clothes
        AddProduct(500, typeof(Clothes));

        //Armor
        AddProduct(2000, typeof(PaperArmor));
        AddProduct(8000, typeof(NormalArmor));
        AddProduct(32000, typeof(MagicArmor));
        AddProduct(128000, typeof(DragonArmor));

        //Accessory
        AddProduct(1000000, typeof(SmartPhone));
    }

    void AddProduct(int price, Type productType)
    {
        Product product = new Product(price, productType);
        products.Add(product);
        sellingInfo.Add(product.defaultItemInstance.name, price / 5);
    }
}
