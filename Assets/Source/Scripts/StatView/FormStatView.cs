using UnityEngine;

public class FormStatView : StatView<FormStatModifier>
{
    [SerializeField] private MeshFilter _meshFilter;
    
    public override void UpdateView(FormStatModifier modifier)
    {
        _meshFilter.mesh = modifier.Mesh;
    }
}
