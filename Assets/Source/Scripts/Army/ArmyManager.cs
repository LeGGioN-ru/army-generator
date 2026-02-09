using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;
using Random = UnityEngine.Random;

public class ArmyManager : MonoBehaviour
{
    [SerializeField] private SoliderFactory _soliderFactory;
    [SerializeField] private List<SoliderSpawnPoint> _spawnPoints;

    private ObjectPool<SoliderPresenter> _soliderPool;
    private HashSet<SoliderPresenter> _activeSoliders = new HashSet<SoliderPresenter>();

    [Inject] private SignalBus _signalBus;

    private void Awake()
    {
        _soliderPool = new ObjectPool<SoliderPresenter>(_soliderFactory.Create,
            soldier =>
            {
                _activeSoliders.Add(soldier);
                _soliderFactory.RandomizeStats(soldier);
                soldier.gameObject.SetActive(true);
                soldier.OnDie += OnSoliderDie;
            },
            soldier =>
            {
                _activeSoliders.Remove(soldier);
                soldier.OnDie -= OnSoliderDie;
                soldier.gameObject.SetActive(false);
            },
            soldier => { Destroy(soldier.gameObject); }, defaultCapacity: 40);
    }

    private void Start()
    {
        GenerateArmy();
    }

    public void GenerateArmy()
    {
        foreach (SoliderSpawnPoint soliderSpawnPoint in _spawnPoints)
        {
            SoliderPresenter solider = _soliderPool.Get();
            solider.View.transform.position = soliderSpawnPoint.transform.position;
            solider.SetArmyType(soliderSpawnPoint.ArmyType);
        }
    }

    public void RegenerateArmy()
    {
        ClearObjectPool();
        GenerateArmy();
    }

    private void OnSoliderDie(SoliderPresenter soldier)
    {
        _soliderPool.Release(soldier);
        CheckToWin();
    }

    private void CheckToWin()
    {
        var survivorGroups = _activeSoliders
            .Where(x => x.gameObject.activeSelf)
            .GroupBy(s => s.Model.ArmyType)
            .ToList();

        if (survivorGroups.Count <= 1)
        {
            var winnerKey = survivorGroups.FirstOrDefault()?.Key;
            if (winnerKey != null) 
            {
                _signalBus.Fire(new GameEndedSignal(winnerKey.Value));
            }

            ClearObjectPool();
        
            _activeSoliders.Clear();
            GenerateArmy();
        }
    }

    private void ClearObjectPool()
    {
        var soldiersToRelease = _activeSoliders.ToList(); 
        
        foreach (SoliderPresenter activeSolider in soldiersToRelease)
        {
            _soliderPool.Release(activeSolider);
        }
    }

    public SoliderPresenter TakeRandomOpponent(ArmyType armyType)
    {
        List<SoliderPresenter> enemyPresenters = _activeSoliders.Where(x => x.Model.ArmyType != armyType).ToList();

        if (enemyPresenters.Count == 0)
            return null;

        return enemyPresenters[Random.Range(0, enemyPresenters.Count)];
    }
}