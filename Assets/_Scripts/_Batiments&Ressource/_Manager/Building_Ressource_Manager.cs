using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Ressource_Manager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private int _stockPucerons;

    public static Building_Ressource_Manager instance;

    [SerializeField] private GameObject _villeMante;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        player.transform.position = new Vector3(_villeMante.transform.position.x, _villeMante.transform.position.y,transform.position.z);
    }
    void Update()
    {
        
    }
    public void AddPucerons(int value)
    {
        _stockPucerons += value;
        // ui synchro
    }
}
