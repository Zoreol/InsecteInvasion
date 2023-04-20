using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ville_Gendarme_Sauvage : MonoBehaviour
{
    public Ville_Gendarme vg;
    [SerializeField] private GameObject _gendarme;
    [SerializeField] private GameObject _spawn;
    [SerializeField] float _timer_siege = 45;
    [SerializeField] Ville_Gendarme_Sauvage vgs;
    private float _timeSpawn = 30;
    private int _maxUnit = 10;
    private int _currentUnit = 0;
    private bool _siege = false;
    private void Awake()
    {
        vg.selectionOn = true;
    }

    private void Update()
    {
        SiegeTime();
        TimeBetweenSpawn();
    }
    void SiegeTime()
    {
        if (_siege)
        {
            _timer_siege -= Time.deltaTime;
            if(_timer_siege <= 0)
            {
                vg.enabled = true;
                vg.selectionOn = false;
                vgs.enabled = false;
            }
        }
        if (!_siege)
        {
            _timer_siege = 45;
        }
    }
    void TimeBetweenSpawn()
    {
        if(_timeSpawn > 0 && _currentUnit < _maxUnit && _siege == false)
        {
            _timeSpawn -= Time.deltaTime;
        }
        if(_timeSpawn <= 0 && _currentUnit < _maxUnit && _siege == false)
        {
            SpawnGendarme();
            _currentUnit++;
            _timeSpawn = 30;
        }
    }
    void SpawnGendarme()
    {
        Instantiate(_gendarme, _spawn.transform);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Mantis")
        {
            _siege = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Mantis")
        {
            _siege = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Mantis")
        {
            _siege = false;
        }
    }
}
