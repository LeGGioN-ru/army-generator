using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/View Stats/Color Modifier", fileName = "Color Modifier")]
public class ColorStatModifier : ViewModifier
{
    [SerializeField] private Color _color;

    public Color Color => _color;
}
