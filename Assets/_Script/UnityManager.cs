using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityManager : MonoBehaviour
{
    [SerializeField] public float life;
    [SerializeField] public bool inDeplacementCondition;
    [SerializeField] float maxLife;
    [SerializeField] float attack;

    [SerializeField] public float speed;


    [SerializeField] public Vector2 posDirection;

    private void Start()
    {
        inDeplacementCondition = false;
        life = maxLife;
    }
    private void Update()
    {
        transform.Translate(posDirection.normalized * (speed * Time.deltaTime), Space.World);
        //CheckDeplacement();
    }
    public void InDeplacement(Vector2 pos)
    {
        transform.position = pos;
    }
    void CheckDeplacement()
    {
        if (inDeplacementCondition)
        {
            transform.Translate(posDirection.normalized * (speed * Time.deltaTime), Space.World);
        }
        if (transform.position.x == posDirection.x && transform.position.y == posDirection.y)
        {
            inDeplacementCondition = false;
        }
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
