using System;
using UnityEngine;
using Zenject;

[Serializable]
public struct EnemyDistanceTransition : ITransition
{
    [SerializeField] private float _needDistance;
    [SerializeField] private bool _enoughDistance;

    [Inject] private ISolider _solider;

    public bool CanTransit()
    {
        return (Vector3.Distance(_solider.Transform.position, _solider.AttackTarget.transform.position) > _needDistance) != _enoughDistance;
    }
}