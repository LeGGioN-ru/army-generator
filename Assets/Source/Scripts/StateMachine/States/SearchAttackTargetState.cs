using UnityEngine;
using Zenject;

public class SearchAttackTargetState : State
{
    [Inject] private ISolider _solider;
    [Inject] private ArmyManager _armyManager;

    public override void OnUpdateState()
    {
        if (_solider.AttackTarget != null && _solider.AttackTarget.activeSelf)
            return;

        _solider.SetTarget(_armyManager.TakeRandomOpponent(_solider.Model.ArmyType));
    }
}