using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAUnitManager : UnityManager
{
    [SerializeField] public float xMinLimit, xMaxLimit, yMinLimit, yMaxLimit;

    private bool stopMovement = false;
    private void Start()
    {
        DeplacementRandom();
    }

    void DeplacementRandom()
    {
        float randomX = Random.Range(xMinLimit, xMaxLimit);
        float randomY = Random.Range(yMinLimit, yMaxLimit);
        Vector2 randomPosition = new Vector2(randomX, randomY);
        InDeplacement(randomPosition);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeDamage();
        }
    }
}
