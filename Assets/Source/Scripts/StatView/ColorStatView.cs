using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorStatView : StatView<ColorStatModifier>
{
    [SerializeField] private Renderer _renderer;

    public override void UpdateView(ColorStatModifier modifier)
    {
        _renderer.material.color = modifier.Color;
    }
}