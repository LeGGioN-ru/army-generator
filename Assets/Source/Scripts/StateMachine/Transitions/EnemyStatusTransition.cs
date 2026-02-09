using System;
using UnityEngine;
using Zenject;

[Serializable]
public class EnemyStatusTransition : ITransition
{
    [SerializeField] private bool _haveEnemy;
    [Inject] private ISolider _solider;

    public bool CanTransit()
    {
        return (_solider.AttackTarget != null && _solider.AttackTarget.gameObject.activeSelf) == _haveEnemy;
    }
}