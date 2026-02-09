using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/View Stats/Form Modifier", fileName = "Form Modifier")]
public class FormStatModifier : ViewModifier
{
   [SerializeField] private Mesh _mesh;

   public Mesh Mesh => _mesh;
}
