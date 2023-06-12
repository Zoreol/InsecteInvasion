using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ville_Araigne : MonoBehaviour
{
    [SerializeField] private GameObject _araigne;
    //[SerializeField] private GameObject _boss_araigne;
    [SerializeField] private GameObject _spawn;
    [SerializeField] private GameObject _floor_araigne;
    [SerializeField] private GameObject _formation;
    [SerializeField] float _timer_siege = 45;
    [SerializeField] Ville_Araigne va;
    [SerializeField] private GameObject _spider_Boss;
    [SerializeField] private GameObject _spider_Boss_Spawn;
    [SerializeField] private bool _siege = false;
    [SerializeField] private bool _boss_Spawn = false;
    private float _timeSpawn = 30;
    private int _maxUnit = 10;
    public int _currentUnit = 0;
    public bool _boos_killed = false;
    

    public bool Ville_Spider_Captured = false;

    private void Update()
    {
        SiegeTime();
        TimeBetweenSpawn();
    }
    void SiegeTime()
    {
        if(_siege && !_boos_killed && !_boss_Spawn)
        {
            _boss_Spawn = true;
            Instantiate(_spider_Boss, _spider_Boss_Spawn.transform);
        }
        if (_siege && _boos_killed)
        {
            _timer_siege -= Time.deltaTime;
            if (_timer_siege <= 0)
            {
                //ville capturer
                Ville_Spider_Captured = true;
                //
                va.enabled = false;
            }
        }
        if (!_siege)
        {
            _timer_siege = 45;
        }
    }
    void TimeBetweenSpawn()
    {
        if (_timeSpawn > 0 && _currentUnit < _maxUnit && _siege == false)
        {
            _timeSpawn -= Time.deltaTime;
        }
        if (_timeSpawn <= 0 && _currentUnit < _maxUnit && _siege == false)
        {
            SpawnGendarme();
            _currentUnit++;
            _timeSpawn = 30;
        }
    }
    void SpawnGendarme()
    {
        //Instantiate(_araigne, _spawn.transform);
        GameObject newAraigne = Instantiate(_araigne, _spawn.transform);

        newAraigne.GetComponent<IAUnitManager>().floor = _floor_araigne;
        newAraigne.GetComponent<IAUnitManager>().formationPoint = _formation.transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mantis")
        {
            _siege = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Mantis")
        {
            _siege = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Mantis")
        {
            _siege = false;
        }
    }
}
