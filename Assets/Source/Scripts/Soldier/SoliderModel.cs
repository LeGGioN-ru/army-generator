using UnityEngine;

public class SoliderModel
{
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Speed { get; private set; }
    public int AttackSpeed { get; private set; }
    public ArmyType ArmyType { get; private set; }

    public SoliderModel()
    {
        Health = 100;
        Attack = 10;
        Speed = 10;
        AttackSpeed = 1;
    }

    public void ApplyStats(StatModifier modifier)
    {
        foreach (StatModifierContainer stat in modifier.Stats)
        {
            switch (stat.ModifierType)
            {
                case StatModifierType.HP:
                    Health += stat.Value;
                    break;
                case StatModifierType.ATK:
                    Attack += stat.Value;
                    break;
                case StatModifierType.SPEED:
                    Speed += stat.Value;
                    break;
                case StatModifierType.ATKSPD:
                    AttackSpeed += stat.Value;
                    break;
            }
        }
    }

    public void SetArmyType(ArmyType armyType)
    {
        ArmyType = armyType;
    }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}