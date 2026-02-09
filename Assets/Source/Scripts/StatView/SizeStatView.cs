using UnityEngine;

public class SizeStatView : StatView<SizeStatModifier>
{
    [SerializeField] private Transform _root;

    public override void UpdateView(SizeStatModifier size)
    {
        _root.localScale = new Vector3(size.Scale, size.Scale, size.Scale);
    }
}