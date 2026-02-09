using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private List<State> _states;
    [SerializeField] private State _startState;

    [Inject] private DiContainer _diContainer;

    public State CurrentState { get; private set; }

    private void Start()
    {
        CurrentState = _startState;
        _states = _states.OrderBy(x => x.Order).ToList();

        foreach (State state in _states)
            foreach (ITransition transition in state.Transitions)
                _diContainer.Inject(transition);
    }

    private void Update()
    {
        foreach (State state in _states)
        {
            if (state.Transitions.All(x => x.CanTransit()))
            {
                if (CurrentState == state)
                {
                    CurrentState.OnUpdateState();
                    return;
                }

                CurrentState.OnDisableState();
                CurrentState = state;
                CurrentState.OnEnableState();
            }
        }

        CurrentState.OnUpdateState();
    }
}