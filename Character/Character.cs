using System;
using System.Threading;

public class Character
{
    public int level { get; protected set; } = 1;
    public string name { get; }
    public CharacterStats originalStats { get; }
    public CharacterStats additionalStats { get; set; }
    public CharacterStats stats
    {
        get
        {
            return originalStats + additionalStats;
        }
    }

    public EquipmentComponent equipmentComponent { get; } = new EquipmentComponent();
    public int health { get; set; }

    public bool isDead => health <= 0;
    public int attack => new Random().Next(stats.minAttack, stats.maxAttack);

    public Character(string name, CharacterStats originalStats)
    {
        this.name = name;
        this.originalStats = originalStats;
        this.health = originalStats.maxHealth;
        equipmentComponent.OnEquipDelegate += OnEquip;
        equipmentComponent.OnUnequipDelegate += OnUnequip;
    }

    public void takeDamage(int damage)
    {
        Random rnd = new Random();

        damage -= rnd.Next(stats.minArmor, stats.maxArmor + 1);
        if (damage <= 0)
        {
            damage = 1;
        }

        health -= damage;
        Console.WriteLine($"{name}이(가) {damage}의 데미지를 받았습니다");
        Thread.Sleep(500);
        if (isDead)
        {
            Console.WriteLine($"{name}이(가) 죽었습니다.");
        }
        else
        {
            Console.WriteLine($"{name}의 남은 체력: {health}/{stats.maxHealth}");
        }
    }

    void OnEquip(IEquipableItem equipableItem)
    {
        additionalStats += equipableItem.additionalStats;
    }

    void OnUnequip(IEquipableItem equipableItem)
    {
        additionalStats -= equipableItem.additionalStats;
    }
}