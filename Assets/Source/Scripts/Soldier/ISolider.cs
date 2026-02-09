using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISolider
{
    public void Attack();
    public void SetTarget(SoliderPresenter soliderPresenter);
    public SoliderModel Model { get; }
    public GameObject AttackTarget { get; }
    public Transform Transform { get; }
}