using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAUnitManager : UnityManager
{
    public float timePaused;
    public float timeTraved;
    public float timeTurn;
    public float maxTimeTraved;
    public GameObject floor;
    public Vector3 targetPosition;

    private Vector2 moveto;
    private Bounds bndFloor;
    private LineRenderer line = null;

    private float px;
    private float py;


    void Start()
    {
        bndFloor = floor.GetComponent<SpriteRenderer>().bounds;


        line = this.gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.widthMultiplier = 0.2f;

        StartCoroutine(SetRandomDestination());

    }

    void Update()
    {
        //pour le deplacement aleatoire
        // Calcule la direction vers la cible
        Vector2 direction = targetPosition  - transform.position;

        // Vérifie si l'objet est arrivé à la cible
        if (direction.magnitude < 0.1f)
        {
            return;
        }

        // Normalise la direction et multiplie par la vitesse
        Vector2 movement = direction.normalized * speed * Time.deltaTime;

        // Déplace l'objet dans la direction de la cible
        transform.Translate(movement, Space.World);
    }
    
    IEnumerator SetRandomDestination()
    {
        px = Random.Range(bndFloor.min.x + 0.5f, bndFloor.max.x - 0.5f);
        py = Random.Range(bndFloor.min.z + 0.5f, bndFloor.max.z - 0.5f);
        //moveto = new Vector3(Mathf.Lerp(minimum, maximum, timeTraved),0,0);
        moveto = new Vector2(px, py);
        targetPosition = moveto;
        InDeplacement(moveto);
        Debug.Log(moveto);

        //agent.SetDestination(moveto);

        //Invoke("CheckPointOnPath", 0.2f);

        yield return new WaitForSeconds(timePaused);

        StartCoroutine(SetRandomDestination());
    }
}
