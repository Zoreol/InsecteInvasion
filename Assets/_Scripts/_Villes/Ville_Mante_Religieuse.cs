using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ville_Mante_Religieuse : MonoBehaviour
{
    [SerializeField] private GameObject[] _mantes;
    [SerializeField] private GameObject _villeInterface;
    [SerializeField] private GameObject _villeBouton;
    private int _unitNumberCreating = 0;
    private Transform _villePosition;
    private bool _creationUnit;
    public float timerSpawnBaseUnit = 10f;
    public int maxUnit = 15;
    public int numberUnit = 0;

    private void Start()
    {
        _villePosition = this.transform;
    }
    private void Update()
    {
        CreateUnitStart();
        TimeBeforeUnitCreation();
    }

    public void AffichageVilleInterface()
    {
        _villeInterface.SetActive(true);
        _villeBouton.SetActive(false);
    }
    public void SpawnUnitBase()
    {
        if((numberUnit + _unitNumberCreating) < maxUnit)
        {
            _unitNumberCreating++;
        }
    }
    public void LeaveUnitUI()
    {
        _villeInterface.SetActive(false);
        _villeBouton.SetActive(true);
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
        if (_creationUnit == true && numberUnit < maxUnit)
        {
            timerSpawnBaseUnit -= Time.deltaTime;
        }
        if (timerSpawnBaseUnit <= 0)
        {
            numberUnit++;
            _unitNumberCreating--;
            Instantiate(_mantes[0], _villePosition);
            timerSpawnBaseUnit = 10;
        }
    }
}
