using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_Ville : MonoBehaviour
{
    [SerializeField] private GameObject _boutonVille;
    [SerializeField] private Ville_Mante_Religieuse vMR;
    private void OnMouseOver()
    {
        if (!vMR.selectionOn)
        {
            _boutonVille.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        _boutonVille.SetActive(false);
    }

}
