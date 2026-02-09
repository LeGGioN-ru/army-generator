using System;
using UnityEngine;

public abstract class StatView<T> : BaseStatView where T : ViewModifier
{
    public override Type DataType => typeof(T);

    public override void UpdateViewCommon(ViewModifier modifier)
    {
        if (modifier is T concreteModifier)
        {
            UpdateView(concreteModifier);
        }
        else
        {
            Debug.LogWarning($"View {name} получила неверный тип данных. Ожидалось: {typeof(T)}, пришло: {modifier.GetType()}");
        }
    }

    public abstract void UpdateView(T modifier);
}

[Serializable]
public abstract class BaseStatView : MonoBehaviour
{
    public abstract Type DataType { get; }

    public abstract void UpdateViewCommon(ViewModifier modifier);
}