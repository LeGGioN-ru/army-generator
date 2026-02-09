using UnityEngine;
using Zenject;

public class GameTimeManager : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;

    private void OnEnable()
    {
        _signalBus.Subscribe<GameEndedSignal>(OnGameEnded);
        _signalBus.Subscribe<GameStartSignal>(OnGameStart);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<GameEndedSignal>(OnGameEnded);
        _signalBus.Unsubscribe<GameStartSignal>(OnGameStart);
    }

    private void Start()
    {
        Time.timeScale = 0;
    }
    
    private void OnGameStart()
    {
        Time.timeScale = 1;
    }
    
    private void OnGameEnded()
    {
        Time.timeScale = 0;
    }
}