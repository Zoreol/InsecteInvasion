using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAUnitManager : UnityManager
{
    [SerializeField] public float xLimit = 5.0f;
    [SerializeField] public float yLimit = 5.0f;

    private bool stopMovement = false;
    private void Start()
    {
        StartCoroutine(DeplacementRandom());
    }

    IEnumerator DeplacementRandom()
    {
        while (true)
        {
            if (!stopMovement)
            {
                inDeplacementCondition = true;
                ChangeDirection();
                Vector2 movement = posDirection * speed;
                float elapsedTime = 0.0f;
                while (elapsedTime < 2.0f)
                {
                    Vector2 newPosition = (Vector2)transform.position + movement * Time.deltaTime;
                    newPosition.x = Mathf.Clamp(newPosition.x, -xLimit, xLimit);
                    newPosition.y = Mathf.Clamp(newPosition.y, -yLimit, yLimit);
                    InDeplacement(newPosition);
                    //transform.position = newPosition;
                    elapsedTime += Time.deltaTime;
                    
                    yield return null;
                }
                inDeplacementCondition = false;

            }

            
        }

        //yield return new WaitForSeconds(3f);

        //StartCoroutine(DeplacementRandom());
    }
    void ChangeDirection()
    {
        posDirection = Random.insideUnitCircle.normalized;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TakeDamage();
        }
    }
}
