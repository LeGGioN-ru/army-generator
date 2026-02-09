using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/View Stats/Size Modifier", fileName = "Size Modifier")]
public class SizeStatModifier : ViewModifier
{
    [SerializeField] private float _scale;

    public float Scale => _scale;
}