using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAUnitManager : UnityManager
{
    [SerializeField] public float xMinLimit, xMaxLimit, yMinLimit, yMaxLimit;
    [SerializeField] float tempsEntrePositions = 2f;

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
        Invoke("NouvellePositionCible", tempsEntrePositions);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeDamage();
        }
    }
    /*
    public void DeplacementRandom1()
    {
        // Appeler NouvellePositionCible() une première fois
        NouvellePositionCible();
    }*/
}
