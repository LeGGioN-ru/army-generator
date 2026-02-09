using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeReference] private List<ITransition> _transitions;
    [SerializeField] private int _order;
    
    public int Order => _order;
    public IReadOnlyList<ITransition> Transitions => _transitions;

    public virtual void OnEnableState()
    {
    }

    public virtual void OnUpdateState()
    {
    }

    public virtual void OnDisableState()
    {
    }
}