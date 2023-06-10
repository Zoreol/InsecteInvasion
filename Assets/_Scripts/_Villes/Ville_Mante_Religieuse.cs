using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ville_Mante_Religieuse : MonoBehaviour
{
    [SerializeField] private GameObject[] _mantes;
    [SerializeField] private GameObject _villeInterface;
    [SerializeField] private GameObject _villeBouton;
    [SerializeField] private GameObject _SpawnMante;
    private int _unit_creating;
    private int _unitNumberCreating = 0;
    private bool _creationUnit;
    public float timerSpawnBaseUnit = 10f;
    public int maxUnit = 15;
    public bool selectionOn = false;

    
    private void Start()
    {
    }
    private void Update()
    {
        CreateUnitStart();
        TimeBeforeUnitCreation();
    }

    /*public void AffichageVilleInterface()
    {
        _villeInterface.SetActive(true);
        _villeBouton.SetActive(false);
        selectionOn = true;
    }*/
    public void SpawnUnitBase()
    {
        if((Unit_number.number_unit + _unitNumberCreating) < maxUnit)
        {
            _unit_creating = 0;
            _unitNumberCreating++;
        }
    }
    public void LeaveUnitUI()
    {
        _villeInterface.SetActive(false);
        selectionOn = false;
    }

    private void CreateUnitStart()
    {
        if(_unitNumberCreating > 0)
        {
            _creationUnit = true;
            
        }else _creationUnit = false;
    }
    private void TimeBeforeUnitCreation()
    {
        if (_creationUnit == true && Unit_number.number_unit < maxUnit)
        {
            timerSpawnBaseUnit -= Time.deltaTime;
        }
        if (timerSpawnBaseUnit <= 0)
        {
            Unit_number.number_unit++;
            _unitNumberCreating--;
            Instantiate(_mantes[0], _SpawnMante.transform);
            // info spawn unité
            //
            timerSpawnBaseUnit = 10;
        }
    }
    public void Supression_Mantes()
    {
        Unit_number.number_unit = 0;
        for (int i = 0; i < _mantes.Length; i++)
        {
            Destroy(_mantes[i]);
        }
    }
}
