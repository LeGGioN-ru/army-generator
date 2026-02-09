using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class RegenerateArmysButton : MonoBehaviour
{
    [Inject] private ArmyManager _armyManager;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnRegenerateClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnRegenerateClick);
    }

    private void OnRegenerateClick()
    {
        _armyManager.RegenerateArmy();
    }
}
