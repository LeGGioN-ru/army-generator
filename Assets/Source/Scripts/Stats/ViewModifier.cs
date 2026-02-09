using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

public class ViewModifier : ScriptableObject
{
    [SerializeField] private StatModifier _statModifier;

    public StatModifier StatModifier => _statModifier;
}
