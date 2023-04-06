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
    public List<IAUnitManager> IAUnitManager_List;
    public Transform formationPoint;

    private Vector2 moveto;
    private Bounds bndFloor;
    private float timePaused;
    private bool copain;

    private void Awake()
    {
        IAUnitManager_List = new List<IAUnitManager>();
    }

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

    void DefencePosition(GameObject target)
    {
        moveto = new Vector2(formationPoint.position.x, formationPoint.position.y);
        List<Vector2> targetPositionList = GetPositionListAround(moveto, 1f, 5);

        int targetPositionIndex = 0;
        foreach (IAUnitManager IAUnitManager in IAUnitManager_List)
        {
            IAUnitManager.InDeplacement(targetPositionList[targetPositionIndex]);
            targetPositionIndex = (targetPositionIndex + 1) % targetPositionList.Count;
        }
        if (IAUnitManager_List.Count == 0)
        {
            InDeplacement(moveto);
        }
    }

    private List<Vector2> GetPositionListAround(Vector2 startPosition,float distance,int positionCount)
    {
        List<Vector2> positionList = new List<Vector2>();
        for (int i = 0; i < positionCount; i++)
        {
            float angle = i * (360f / positionCount);
            Vector2 dir = ApplyRotationToVector(new Vector2(1, 0), angle);
            Vector2 position = startPosition + dir * distance;
            positionList.Add(position);
        }
        return positionList;
    }

    Vector2 ApplyRotationToVector(Vector2 vector, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * vector;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gendarme"))
        {
            IAUnitManager_List.Add(collision.gameObject.GetComponent<IAUnitManager>());
            copain = true;
            Debug.Log("J'ai un copain a coter");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DefencePosition(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Gendarme"))
        {
            IAUnitManager_List.Remove(collision.gameObject.GetComponent<IAUnitManager>());
            copain = false;
            Debug.Log("J'ai plus de copain");
        }
    }
}
