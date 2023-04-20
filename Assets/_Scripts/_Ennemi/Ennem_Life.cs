using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennem_Life : MonoBehaviour
{
    public int health;
    [SerializeField] private int _max_health;
    void Start()
    {
        health = _max_health;
    }
    private void Update()
    {
        Death();
    }
    void Death()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
