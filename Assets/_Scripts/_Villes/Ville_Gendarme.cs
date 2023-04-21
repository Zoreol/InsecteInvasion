using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ville_Gendarme : MonoBehaviour
{
    [SerializeField] private GameObject[] _mantes;
    [SerializeField] private GameObject _villeInterface;
    [SerializeField] private GameObject _villeBouton;
    [SerializeField] private GameObject _SpawnMante;
    [SerializeField] private GameObject _mantank_bouton;
    [SerializeField] private GameObject _base_unit;
    //[SerializeField] private GameObject _Direction_spawn_unit;
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
        IntteractionSpawnUnit();
    }

    public void AffichageVilleInterface()
    {
        _villeInterface.SetActive(true);
        _villeBouton.SetActive(false);
        selectionOn = true;
    }
    public void SpawnUnitBase()
    {
        //if ((numberUnit + _unitNumberCreating) < maxUnit)
        if ((Unit_number.number_unit + _unitNumberCreating) < maxUnit)
        {
            _unit_creating = 0;
            _unitNumberCreating++;
        }
    }
    public void SpawnUnitTank()
    {
        if ((Unit_number.number_unit + _unitNumberCreating) < maxUnit)
        {
            _unit_creating = 1;
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
        if (_unitNumberCreating > 0)
        {
            _creationUnit = true;
        }
        else _creationUnit = false;
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
            Instantiate(_mantes[_unit_creating], _SpawnMante.transform);
            
            if (_unit_creating == 0)
            {
                timerSpawnBaseUnit = 10;
            }
            if(_unit_creating == 1)
            {
                timerSpawnBaseUnit = 20;
            }

            Debug.Log(Unit_number.number_unit);
        }
    }
    void IntteractionSpawnUnit()
    {
        if (_unitNumberCreating > 0 && _unit_creating == 0)
        {
            _mantank_bouton.GetComponent<Button>().interactable = false;
        }
        if (_unitNumberCreating > 0 && _unit_creating == 1)
        {
            _base_unit.GetComponent<Button>().interactable = false;
        }
        else if (_unitNumberCreating <= 0)
        {
            _mantank_bouton.GetComponent<Button>().interactable = true;
            _base_unit.GetComponent<Button>().interactable = true;
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
