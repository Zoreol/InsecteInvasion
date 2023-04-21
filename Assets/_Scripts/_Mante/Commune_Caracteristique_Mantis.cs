using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commune_Caracteristique_Mantis : MonoBehaviour
{
    public  int health;
    public  int damage;
    public int _maxHealth;
    private void Awake()
    {
        health = _maxHealth;
    }

}
