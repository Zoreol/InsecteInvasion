using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_Ville_Gendarme : MonoBehaviour
{
    [SerializeField] private GameObject _boutonVille;
    [SerializeField] private Ville_Gendarme vg;
    private void OnMouseOver()
    {
        if (!vg.selectionOn)
        {
            _boutonVille.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        _boutonVille.SetActive(false);
    }
}
