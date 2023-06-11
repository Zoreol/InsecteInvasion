using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villes_UI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _building_ui;
    [SerializeField] private GameObject _placement_building_ui;
    [SerializeField] private GameObject[] _batiments_Mantes;
    [SerializeField] private bool[] _batimentsselected;

    public Transform position_Batiment;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Building_UI_Show_UP()
    {
        _building_ui.SetActive(true);
    }
    public void BBuilding_UI_Close()
    {
        _building_ui.SetActive(false);
    }
    public void Selecte_Batiments_Tank()
    {
        _batimentsselected[0] = true;
        _batimentsselected[1] = false;
        _batimentsselected[2] = false;
        _placement_building_ui.SetActive(true);

    }
    public void Selecte_Batiments_Recolte()
    {
        _batimentsselected[0] = false;
        _batimentsselected[1] = true;
        _batimentsselected[2] = false;
        _placement_building_ui.SetActive(true);
    }
    public void Selecte_Batiments_Bolas()
    {
        _batimentsselected[0] = false;
        _batimentsselected[1] = false;
        _batimentsselected[2] = true;
        _placement_building_ui.SetActive(true);
    }

    public void Place_Buiilding()
    {
        if(_batimentsselected[0] == true)
        {
            Instantiate(_batiments_Mantes[0], position_Batiment.transform);
            _batimentsselected[0] = false;
            _batimentsselected[1] = false;
            _batimentsselected[2] = false;
            _placement_building_ui.SetActive(false);
        }
        if (_batimentsselected[1] == true)
        {
            Instantiate(_batiments_Mantes[1], position_Batiment.transform);
            _batimentsselected[0] = false;
            _batimentsselected[1] = false;
            _batimentsselected[2] = false;
            _placement_building_ui.SetActive(false);
        }
        if (_batimentsselected[2] == true)
        {
            Instantiate(_batiments_Mantes[2], position_Batiment.transform);
            _batimentsselected[0] = false;
            _batimentsselected[1] = false;
            _batimentsselected[2] = false;
            _placement_building_ui.SetActive(false);
        }
        if (_batimentsselected[3] == true)
        {
            Instantiate(_batiments_Mantes[3], position_Batiment.transform);
            _batimentsselected[0] = false;
            _batimentsselected[1] = false;
            _batimentsselected[2] = false;
            _placement_building_ui.SetActive(false);
        }
    }
}
