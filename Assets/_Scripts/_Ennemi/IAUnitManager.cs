using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAUnitManager : UnityManager
{
    //paramettre des unit IA Paramettre
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
    public bool spider;

    private void Awake()
    {
        //creer une list d'unit pour pourvoir ce rassembler si il y a une attaque
        IAUnitManager_List = new List<IAUnitManager>();
        
    }

    void Start()
    {
        //cherche moi ma capacité de deplacement
        bndFloor = floor.GetComponent<SpriteRenderer>().bounds;
        //IAUnitManager_List.Clear();
        StartCoroutine(SetRandomDestination());
    }
    public void Attack()
    {
        Debug.Log("J'attaque ?");
        //en fonction de la distance je met plus ou moins de degat
        if (Vector2.Distance(this.gameObject.transform.position, playerUnit[0].transform.position) <= 2)
        {
            animUnit.SetTrigger("DistanceCourt");
            playerUnit[0].GetComponent<UnityManager>().life-= 2f;
        }
        else
        {
            animUnit.SetTrigger("DistanceLong");
            playerUnit[0].GetComponent<UnityManager>().life -= 1f;
            playerUnit[0].GetComponent<UnityManager>().StartCoroutine(InStun());
        }
         
    }
    IEnumerator SetRandomDestination()
    {
        //creer moi un nouvelle destination
        float px = Random.Range(bndFloor.min.x + 0.5f, bndFloor.max.x - 0.5f);
        float py = Random.Range(bndFloor.min.y + 0.5f, bndFloor.max.y - 0.5f);
        timePaused = Random.Range(timePausedMin, timePausedMax);
        moveto = new Vector2(px, py);
        //Donne l'info que tu peux partir
        InDeplacement(moveto);

        yield return new WaitForSeconds(timePaused);

        StartCoroutine(SetRandomDestination());
    }

    void GroupPosition(GameObject target)
    {
        //en fonction de ma liste tu creer une formation
        moveto = new Vector2(formationPoint.position.x, formationPoint.position.y);
        List<Vector2> targetPositionList = GetPositionListAround(moveto, 1f, 5);
        
        int targetPositionIndex = 0;
        foreach (IAUnitManager IAUnitManager in IAUnitManager_List)
        {
            for (int i = 0; i < IAUnitManager_List.Count; i++)
            {
                if (IAUnitManager_List[i] != null)
                {
                    IAUnitManager.InDeplacement(targetPositionList[targetPositionIndex]);
                    targetPositionIndex = (targetPositionIndex + 1) % targetPositionList.Count;
                }
            }
            
        }
        if (IAUnitManager_List.Count == 0 || IAUnitManager_List[0] == null)
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
    //pour dire si il y a une personne de son coter ou pas
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gendarme") == this.gameObject.CompareTag("Gendarme"))
        {
            IAUnitManager_List.Add(collision.gameObject.GetComponent<IAUnitManager>());
        }
        if (collision.CompareTag("Mantis"))
        {
            PlayerTarget = true;

            playerUnit.Add(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mantis"))
        {
            TargetPlayer(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < IAUnitManager_List.Count; i++)
        {
            if (IAUnitManager_List[i] == null)
            {
                IAUnitManager_List.Remove(IAUnitManager_List[i]);
            }
        }
        
        if (collision.CompareTag("Gendarme"))
        {
            IAUnitManager_List.Remove(collision.gameObject.GetComponent<IAUnitManager>());
        }
        if (collision.CompareTag("Mantis"))
        {
            playerUnit.Remove(collision.gameObject);
            PlayerTarget = false;
            timePaused = 4;
            animUnit.SetBool("inFormation", false);
        }
    }

    void TargetPlayer(Collider2D collision)
    {
        if (!PlayerTarget) return;

        if (PlayerTarget && spider)
        {
            canAttack = true;
        }
        InAttack();
        GroupPosition(collision.gameObject);
        animUnit.SetBool("inFormation", true);
        if (PlayerTarget && InFormation)
        {

            animUnit.SetBool("Marche", false);
        }

        if (collision.GetComponent<UnityManager>().attackingEnnemi && !TakingDamage)
        {
            TakingDamage = true;
           StartCoroutine(TakeDamage());
        }
    }
}
