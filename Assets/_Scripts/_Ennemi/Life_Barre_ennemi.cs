using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Barre_ennemi : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject unit;
    void Start()
    {
        _slider.maxValue = unit.GetComponent<IAUnitManager>().maxLife;
        _slider.value = unit.GetComponent<IAUnitManager>().life;
    }

    void Update()
    {
        _slider.value = unit.GetComponent<IAUnitManager>().life;
    }
}
