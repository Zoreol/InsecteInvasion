using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_villeGendarmeBuilding : MonoBehaviour
{
    [SerializeField] private Villes_UI _vU;
    public void villeGendarmeUI()
    {
        _vU.ville_gendarme_activated = true;
    }
}
