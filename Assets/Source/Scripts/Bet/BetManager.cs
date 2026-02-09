using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BetManager : MonoBehaviour
{
    [SerializeField] private int _needBetForWin;

    private ArmyType _betArmy;
    private int _currentAmountWinBet;

    [Inject] private SignalBus _signalBus;

    public int CurrentAmountWinBet => _currentAmountWinBet;
    public int NeedBetForWin => _needBetForWin;
    
    private void OnEnable()
    {
        _signalBus.Subscribe<GameEndedSignal>(OnGameEnd);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<GameEndedSignal>(OnGameEnd);
    }

    public void Bet(ArmyType armyType)
    {
        _betArmy = armyType;
    }

    private void OnGameEnd(GameEndedSignal gameEndedSignal)
    {
        if (_betArmy == gameEndedSignal.ArmyType)
        {
            _currentAmountWinBet++;
        }
        else
        {
            _currentAmountWinBet = 0;
        }
    }
}