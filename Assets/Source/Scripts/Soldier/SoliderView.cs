using System.Collections.Generic;
using UnityEngine;

public class SoliderView : MonoBehaviour
{
    [SerializeField] private List<BaseStatView> _viewModifiers;
    [SerializeField] private Renderer _renderer;

    public void UpdateStatView(ViewModifier viewModifier)
    {
        var statView = _viewModifiers.Find(x => x.DataType == viewModifier.GetType());

        if (statView != null)
        {
            statView.UpdateViewCommon(viewModifier);
        }
        else
        {
            Debug.Log($"Не найдена View для типа {viewModifier.GetType()}");
        }
    }

    public void ResetView()
    {
        transform.localScale = Vector3.one;
        _renderer.material.color=Color.white;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}