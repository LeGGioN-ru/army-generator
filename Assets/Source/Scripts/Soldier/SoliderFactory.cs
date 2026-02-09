using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SoliderFactory : MonoBehaviour
{
    [SerializeField] private SoliderPresenter _template;
    [SerializeField] private List<ColorStatModifier> _colors;
    [SerializeField] private List<SizeStatModifier> _sizes;
    [SerializeField] private List<FormStatModifier> _forms;

    [Inject] private DiContainer _diContainer;

    public SoliderPresenter Create()
    {
        SoliderModel soliderModel = new SoliderModel();

        SoliderPresenter soliderPresenter = _diContainer.InstantiatePrefabForComponent<SoliderPresenter>(_template, Vector3.zero, Quaternion.identity, null);

        soliderPresenter.Initialize(soliderModel);

        return soliderPresenter;
    }

    public void RandomizeStats(SoliderPresenter presenter)
    {
        presenter.ResetState();

        ApplyRandomModifier(presenter, _colors);
        ApplyRandomModifier(presenter, _sizes);
        ApplyRandomModifier(presenter, _forms);
    }

    private void ApplyRandomModifier<T>(SoliderPresenter presenter, List<T> modifiers) where T : ViewModifier
    {
        if (modifiers.Count == 0) return;
        presenter.ApplyViewStat(modifiers[Random.Range(0, modifiers.Count)]);
    }
}