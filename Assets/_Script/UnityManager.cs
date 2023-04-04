using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityManager : MonoBehaviour
{
    [SerializeField]public float life;
    [SerializeField] float maxLife;
    [SerializeField] float speed;

    private void Start()
    {
        life = maxLife;
    }
    public void InDeplacement(Vector2 pos)
    {
        transform.Translate(pos * Time.deltaTime * speed);
        //transform.position = pos;
    }
    public void TakeDamage()
    {
        life--;
        if (life <= 0f)
        {
            InDeath();
        }
    }

    void InDeath()
    {
        Destroy(gameObject);
    }
    
}
