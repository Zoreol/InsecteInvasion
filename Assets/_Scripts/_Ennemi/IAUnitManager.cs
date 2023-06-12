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
    public GameObject Silk;

    private Vector2 moveto;
    private Bounds bndFloor;
    private float timePaused;

    //je suis un arraign�e donc je peux attaquer
    public bool spider;

    private void Awake()
    {
        //creer une list d'unit pour pourvoir ce rassembler si il y a une attaque
        IAUnitManager_List = new List<IAUnitManager>();
        
    }

    void Start()
    {
        //cherche moi ma capacit� de deplacement
        bndFloor = floor.GetComponent<SpriteRenderer>().bounds;
        StartCoroutine(SetRandomDestination());
    }
    public void Attack()
    {
        //en fonction de la distance j'attaque a distance ou de propre
        if (Vector2.Distance(this.gameObject.transform.position, playerUnit[0].transform.position) <= 2)
        {
            //comme je suis court en distance je fais peut de degat
            animUnit.SetTrigger("DistanceCourt");
            playerUnit[0].GetComponent<UnityManager>().life-= 2f;
        }
        else
        {
            //comme je suis loin j'envoie une toile d'arraign�e
            animUnit.SetTrigger("DistanceLong");
            GameObject SilkTargetPlayer = Instantiate(Silk, transform.position, Quaternion.identity);
            SilkTargetPlayer.GetComponent<SilkManager>().positionCible = playerUnit[0].transform.position;
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
        //Tu me creer un formation des unit�s et tu les anvoie au point de raliment
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
        //Par contre si il es tout seul pas besoin de faire la formation
        if (IAUnitManager_List.Count == 0 || IAUnitManager_List[0] == null)
        {
            InDeplacement(moveto);
        }
    }

    private List<Vector2> GetPositionListAround(Vector2 startPosition,float distance,int positionCount)
    {
        //position de chaque unit� (en mode formation) avec une distance entre chaque unit�
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
    {   // j'ai mon unit� manthe dans mon champ de vision
        if (collision.CompareTag("Mantis"))
        {
            PlayerTarget = true;
            TargetPlayer(collision);

            //je tourne en fonction de l'unit� manthes
            if (InFormation && PlayerTarget)
            {
                Vector2 direction = playerUnit[0].transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                transform.rotation = rotation;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    { 
        //enlever l'unit� de ma liste si je la vois plus
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
        //si j'ai la possibilit� d'attaquer 
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
        /*
        if (collision.GetComponent<UnityManager>().attackingEnnemi && !TakingDamage)
        {
            TakingDamage = true;
           StartCoroutine(TakeDamage());
        }*/
    }
}
