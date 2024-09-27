using System;
using System.Threading;

public enum AttackType
{
    Normal = 0,
    Weak,
    Critical
}

public struct AttackResult
{
    public Character attacker = null;
    public Character target = null;
    public AttackType attackType;
    public int damage;

    public AttackResult()
    {
        attackType = AttackType.Normal;
        damage = 0;
    }
}

public struct TakeDamageResult
{
    public AttackResult attackResult = new AttackResult();
    public int actualDamage;
    public int defenseAmount;

    public TakeDamageResult()
    {
        actualDamage = 0;
        defenseAmount = 0;
    }
}


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

    public Character(string name, CharacterStats originalStats)
    {
        this.name = name;
        this.originalStats = originalStats;
        this.health = originalStats.maxHealth;
        equipmentComponent.OnEquipDelegate += OnEquip;
        equipmentComponent.OnUnequipDelegate += OnUnequip;
    }

    public AttackResult DoAttack(Character target)
    {
        AttackResult attackResult = new AttackResult();
        attackResult.attacker = this;
        attackResult.target = target;

        if(new Random().NextDouble() < this.stats.criticalRate)
        {
            attackResult.attackType = AttackType.Critical;
            attackResult.damage = new Random().Next(this.stats.minAttack * 2, this.stats.maxAttack * 2 + 1);
        }
        else
        {
            attackResult.attackType = AttackType.Normal;
            attackResult.damage = new Random().Next(this.stats.minAttack, this.stats.maxAttack + 1);
        }

        return attackResult;
    }

    public TakeDamageResult takeDamage(AttackResult attackResult)
    {
        TakeDamageResult result = new TakeDamageResult();
        result.attackResult = attackResult;
        result.defenseAmount = (new Random().Next(this.stats.minArmor, this.stats.maxArmor + 1));
        result.actualDamage = attackResult.damage - result.defenseAmount;
        if (result.actualDamage <= 0)
        {
            result.actualDamage = 1;
        }

        return result;
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