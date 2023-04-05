using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAUnitManager : UnityManager
{
    [Header ("IA Settings")]
    public float timePausedMin;
    public float timePausedMax;
    public GameObject floor;
    public Vector2 targetPosition;

    private Vector2 moveto;
    private Bounds bndFloor;
    private float timePaused;


    void Start()
    {
        bndFloor = floor.GetComponent<SpriteRenderer>().bounds;

        StartCoroutine(SetRandomDestination());
        
    }
    
    IEnumerator SetRandomDestination()
    {
        float px = Random.Range(bndFloor.min.x + 0.5f, bndFloor.max.x - 0.5f);
        float py = Random.Range(bndFloor.min.y + 0.5f, bndFloor.max.y - 0.5f);
        timePaused = Random.Range(timePausedMin, timePausedMax);
        moveto = new Vector2(px, py);
        InDeplacement(moveto);

        yield return new WaitForSeconds(timePaused);

        StartCoroutine(SetRandomDestination());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (collision.CompareTag("Gendarme"))
            {
                Debug.Log("J'ai un copain a coter");
            }
            Debug.Log("J'en repere un");
        }
    }
}
