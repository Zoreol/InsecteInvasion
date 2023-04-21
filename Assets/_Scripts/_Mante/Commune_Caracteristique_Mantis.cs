using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Commune_Caracteristique_Mantis : MonoBehaviour
{
    public  int health;
    private int _current_health;
    public  int damage;
    public int _maxHealth;
    public Animator anim;
    private void Awake()
    {
        health = _maxHealth;
        _current_health = health;
    }
    private void Update()
    {
        if(health < 0)
        {
            anim.SetBool("Dead", true);
        }
        if(_current_health != health)
        {
            anim.SetBool("subi_Degats", true);
            _current_health = health;
            anim.SetBool("subi_Degats", false);
        }
    }

}
