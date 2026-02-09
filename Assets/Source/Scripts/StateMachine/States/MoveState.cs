using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoveState : State
{
    [SerializeField] private Transform _movePart;

    [Inject] private ISolider _solider;

    public override void OnUpdateState()
    {
        Vector3 currentPos = _solider.Transform.position;

        Vector3 direction = (_solider.AttackTarget.transform.position - currentPos).normalized;

        float step = _solider.Model.Speed * Time.deltaTime;

        _movePart.position += direction * step;
    }
}