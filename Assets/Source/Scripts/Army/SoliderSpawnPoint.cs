using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderSpawnPoint : MonoBehaviour
{
    [SerializeField] private ArmyType _armyType;

    public ArmyType ArmyType => _armyType;
}
