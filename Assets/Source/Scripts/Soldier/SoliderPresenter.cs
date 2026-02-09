using System;
using UnityEngine;

public class SoliderPresenter : MonoBehaviour, ISolider
{
    [SerializeField] private SoliderView _view;
    [SerializeField] private StateMachine _stateMachine;

    private SoliderModel _soliderModel;
    private SoliderPresenter _attackTarget;

    public SoliderModel Model => _soliderModel;
    public SoliderView View => _view;
    public Transform Transform => _view.transform;
    public GameObject AttackTarget => _attackTarget == null ? null : _attackTarget.View.gameObject;
    public event Action<SoliderPresenter> OnDie;

    public void Initialize(SoliderModel soliderModel)
    {
        _soliderModel = soliderModel;
    }

    public void SetArmyType(ArmyType armyType)
    {
        _soliderModel.SetArmyType(armyType);
    }

    public void ResetState()
    {
        _soliderModel = new SoliderModel();
        _view.ResetView();
        _attackTarget = null;
    }

    public void ApplyViewStat(ViewModifier viewModifier)
    {
        _soliderModel.ApplyStats(viewModifier.StatModifier);
        _view.UpdateStatView(viewModifier);
    }

    public void SetTarget(SoliderPresenter target)
    {
        _attackTarget = target;
    }

    public void Attack()
    {
        _attackTarget.TakeDamage(_soliderModel.Attack);
    }

    private void TakeDamage(int damage)
    {
        _soliderModel.TakeDamage(damage);

        if (_soliderModel.Health <= 0)
        {
            OnDie?.Invoke(this);
            _view.Die();
        }
    }
}