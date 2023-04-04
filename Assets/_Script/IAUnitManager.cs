using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAUnitManager : UnityManager
{
    private void Start()
    {
        StartCoroutine(DeplacementRandom());
    }

    IEnumerator DeplacementRandom()
    {
        Vector2 Pose = new Vector2(Random.Range(-5,5f), Random.Range(-5, 5f));
        InDeplacement(Pose);

        yield return new WaitForSeconds(2f);

        StartCoroutine(DeplacementRandom());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeDamage();
        }
    }
}
