using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_destroy : MonoBehaviour
{
    private GameObject unit_To_Destroy;
    public bool die;
    private float _timer = 0.5f;
    private int _death = 1;

    private void Awake()
    {
        unit_To_Destroy = this.gameObject;
        die = false;
    }
    private void Update()
    {
        if(unit_To_Destroy.GetComponent<IAUnitManager>().life < 0)
        {
            die = true;
            if( _death == 1)
            {
                unit_To_Destroy.GetComponentInParent<Ville_Gendarme_Sauvage>()._currentUnit--;
                _death = 0;
            }
            if(_timer < 0)
            {
                Destroy(this.gameObject);
            }
            _timer -= Time.deltaTime;
        }
    }
}
