using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI _takeBetText;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;

    [Inject] private BetManager _betManager;
    [Inject] private SignalBus _signalBus;

    private void OnEnable()
    {
        _leftButton.onClick.AddListener(() => Bet(ArmyType.ArmyA));
        _rightButton.onClick.AddListener(() => Bet(ArmyType.ArmyB));
        _signalBus.Subscribe<GameEndedSignal>(OnGameEnd);
    }

    private void OnDisable()
    {
        _leftButton.onClick.RemoveListener(() => Bet(ArmyType.ArmyA));
        _rightButton.onClick.RemoveListener(() => Bet(ArmyType.ArmyB));
        _signalBus.Unsubscribe<GameEndedSignal>(OnGameEnd);
    }

    private void OnGameEnd(GameEndedSignal gameEndedSignal)
    {
        string bottomText = _betManager.CurrentAmountWinBet >= _betManager.NeedBetForWin ? "Вы победили!!!" : $"Текущая серия {_betManager.CurrentAmountWinBet}/{_betManager.NeedBetForWin}";
        _takeBetText.text = "Сделайте ставку!<br>" + bottomText;
        _canvasGroup.alpha = 1;
    }

    private void Bet(ArmyType armyType)
    {
        _betManager.Bet(armyType);
        _signalBus.Fire<GameStartSignal>();
        _canvasGroup.alpha = 0;
    }
}