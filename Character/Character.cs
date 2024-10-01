using System;
using System.Threading;

public class Character
{
    public int level { get; protected set; } = 1;
    public string name { get; }
    public CharacterStats originalStats { get; protected set; }
    public CharacterStats levelUpStats { get; protected set; } = new CharacterStats(20, 1, 1, 2, 2, 1, 1, 0.0f, 0.0f);
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

    public Character(string name, CharacterStats originalStats)
    {
        this.name = name;
        this.originalStats = originalStats;
        this.health = originalStats.maxHealth;
        equipmentComponent.OnEquipDelegate += OnEquip;
        equipmentComponent.OnUnequipDelegate += OnUnequip;
    }

    public AttackOrderInfo CreateAttackOrder(Character target)
    {
        AttackOrderInfo attackOrderInfo = new AttackOrderInfo();
        attackOrderInfo.target = target;

        if(new Random().NextDouble() < this.stats.criticalRate)
        {
            attackOrderInfo.attackType = AttackType.CRITICAL;
            int minCriticalAttack = (int)Math.Ceiling(this.stats.minAttack * 1.6f);
            int maxCriticalAttack = (int)Math.Ceiling(this.stats.maxAttack * 1.6f);
            attackOrderInfo.damage = new Random().Next(minCriticalAttack, maxCriticalAttack + 1);
        }
        else
        {
            attackOrderInfo.attackType = AttackType.NORMAL;
            attackOrderInfo.damage = new Random().Next(this.stats.minAttack, this.stats.maxAttack + 1);
        }

        return attackOrderInfo;
    }

    public DefenseOrderInfo CreateDefenseOrder(AttackOrderInfo attackOrderInfo)
    {
        DefenseOrderInfo result = new DefenseOrderInfo();
        result.attackResult = attackOrderInfo;
        result.defenseAmount = (new Random().Next(this.stats.minArmor, this.stats.maxArmor + 1));
        result.actualDamage = attackOrderInfo.damage - result.defenseAmount;
        if (result.actualDamage <= 0)
        {
            result.actualDamage = 1;
        }

        return result;
    }

    public HealOrderInfo CreateHealOrder(Character target)
    {
        HealOrderInfo healOrderInfo = new HealOrderInfo();
        healOrderInfo.target = target;
        //#Todo : Make another stat for healing
        healOrderInfo.healAmount = (new Random().Next(this.stats.minArmor, this.stats.maxArmor));
        return healOrderInfo;
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