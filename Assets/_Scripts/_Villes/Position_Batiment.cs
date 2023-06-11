using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_Batiment : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Villes_UI ville_ui;
    [SerializeField] private Transform position;
    [SerializeField] private GameObject emplacement;

    public void PositionVilleBuild()
    {
        ville_ui.position_Batiment = position;
        emplacement.SetActive(false);
    }
    
}
