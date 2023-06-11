using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building_Datas 
{
    [SerializeField] private string name;
    [SerializeField] private int puceronCost;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject zoneEquipement;

    public string Name => name;
    public GameObject Prefab => prefab;
    public GameObject ZoneEquipement => zoneEquipement;
    public int PuceronCost => puceronCost;
}
