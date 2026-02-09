using UnityEngine;
using Zenject;

public class AttackState : State
{
    [Inject] private ISolider _solider;

    private const float BaseAttackSpeedRatio = 5f;

    private float _attackCooldown;
    private float _timer;

    public override void OnEnableState()
    {
        RecalculateCooldown();
        _timer = 0;
    }

    public override void OnUpdateState()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            PerformAttack();
            ResetTimer();
        }
    }

    private void PerformAttack()
    {
        _solider.Attack();
    }

    private void ResetTimer()
    {
        RecalculateCooldown();
        _timer = _attackCooldown;
    }

    private void RecalculateCooldown()
    {
        float currentAttackSpeed = _solider.Model.AttackSpeed;

        _attackCooldown = currentAttackSpeed / BaseAttackSpeedRatio;
    }
}