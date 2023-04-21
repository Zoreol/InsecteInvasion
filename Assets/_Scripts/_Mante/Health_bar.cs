using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Commune_Caracteristique_Mantis _ccm;
    void Start()
    {
        _slider.maxValue = _ccm._maxHealth;
        _slider.value = _ccm.health;
    }

    void Update()
    {
        _slider.value = _ccm.health;
    }
}
