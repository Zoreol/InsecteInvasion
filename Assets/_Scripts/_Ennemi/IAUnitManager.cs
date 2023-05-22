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
    public List<GameObject> playerUnit;
    public Transform formationPoint;

    private Vector2 moveto;
    private Bounds bndFloor;
    private float timePaused;

    private void Awake()
    {
        IAUnitManager_List = new List<IAUnitManager>();
    }

    void Start()
    {
        bndFloor = floor.GetComponent<SpriteRenderer>().bounds;

        StartCoroutine(SetRandomDestination());
    }
    
    public void Attack()
    {
        if (Vector2.Distance(this.gameObject.transform.position, playerUnit[0].transform.position) <= 2)
        {
            playerUnit[0].GetComponent<UnityManager>().life-= 2f;
        }
        else
        {
            playerUnit[0].GetComponent<UnityManager>().life -= 1f;
            playerUnit[0].GetComponent<UnityManager>().StartCoroutine(InStun());
        }
         
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

    void GroupPosition(GameObject target)
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
        if (collision.CompareTag("Gendarme") == this.gameObject.CompareTag("Gendarme"))
        {
            IAUnitManager_List.Add(collision.gameObject.GetComponent<IAUnitManager>());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mantis"))
        {
            playerUnit.Add(collision.gameObject);
            PlayerTarget = true;
            InAttack();
            GroupPosition(collision.gameObject);
            animUnit.SetBool("inFormation", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Gendarme"))
        {
            IAUnitManager_List.Remove(collision.gameObject.GetComponent<IAUnitManager>());
        }
        if (collision.CompareTag("Player"))
        {
            playerUnit.Remove(collision.gameObject);
            PlayerTarget = false;
            timePaused = 4;
            //animUnit.SetBool("inFormation", false);
        }
    }
}
