using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ville_Mante_Religieuse : MonoBehaviour
{
    [SerializeField] private GameObject _smoke;
    [SerializeField] private GameObject _particle_system;
    [SerializeField] private GameObject[] _mantes;
    [SerializeField] private GameObject _villeInterface;
    [SerializeField] private GameObject _villeBouton;
    [SerializeField] private GameObject _SpawnMante;
    [SerializeField] private Ressource_compteur rc;
    private int _unit_creating;
    private int _unitNumberCreating = 0;
    private bool _creationUnit;
    public float timerSpawnBaseUnit = 10f;
    public int maxUnit = 15;
    public bool selectionOn = false;

    private Tutoriel tutoriel;

    private int _fiveUnitTuto = 0;

    
    private void Start()
    {
        tutoriel = FindObjectOfType<Tutoriel>();
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
        if((Unit_number.number_unit + _unitNumberCreating) < maxUnit && rc.nbRessources >= 3)
        {
            _unit_creating = 0;
            _unitNumberCreating++;
            rc.nbRessources = rc.nbRessources - 3;
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
            
        }else if(_unitNumberCreating<=0) _creationUnit = false;
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
            _smoke.GetComponent<ParticleSystem>().Play();
            _particle_system.GetComponent<ParticleSystem>().Play();
            // info spawn unit�
            //
            /*if (!tutoriel._unitCreation)
            {
                tutoriel._unitCreation = true;
            }
            if (tutoriel._recolterPucerons)
            {
                _fiveUnitTuto++;
                if(_fiveUnitTuto >= 5)
                {
                    _fiveUnitTuto = 5;
                }
            }
            if(!tutoriel._createFiveUnit && _fiveUnitTuto >= 5)
            {
                tutoriel._createFiveUnit = true;
            }*/
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
