using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatModifier
{
    [SerializeField] private List<StatModifierContainer> _stats;

    public IReadOnlyList<StatModifierContainer> Stats => _stats;
}

[Serializable]
public class StatModifierContainer : ISerializationCallbackReceiver
{
    [SerializeField] private StatModifierType _modifierType;
    [SerializeField] private int _value;

    public StatModifierType ModifierType => _modifierType;
    public int Value => _value;

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        /*string digit = Value > 0 ? "+" : "-";
        Name = $"{_modifierType} {digit}{_value}";*/
    }
}

public enum StatModifierType
{
    ATK = 1,
    HP = 2,
    SPEED = 3,
    ATKSPD = 4
}