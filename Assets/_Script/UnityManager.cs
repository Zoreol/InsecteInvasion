using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityManager : MonoBehaviour
{
    [SerializeField] public float life;
    [SerializeField] public bool inDeplacementCondition;
    [SerializeField] float maxLife;
    [SerializeField] float attack;

    [SerializeField] public float speed;


    [SerializeField] public Vector2 posDirection;

    private Vector3 positionActuelle;
    private Vector3 positionCible;

    private void Start()
    {
        inDeplacementCondition = false;
        life = maxLife;
    }
    private void Update()
    {
        //transform.Translate(posDirection.normalized * (speed * Time.deltaTime), Space.World);
        //CheckDeplacement();
        positionActuelle = Vector3.Lerp(positionActuelle, positionCible, speed * Time.deltaTime);

        transform.position = positionActuelle;
    }
    public void InDeplacement(Vector2 nouvellePositionCible)
    {
        positionCible = nouvellePositionCible;
    }
    void CheckDeplacement()
    {
        if (inDeplacementCondition)
        {
            transform.Translate(posDirection.normalized * (speed * Time.deltaTime), Space.World);
        }
        if (transform.position.x == posDirection.x && transform.position.y == posDirection.y)
        {
            inDeplacementCondition = false;
        }
    }
    public void TakeDamage()
    {
        life--;
        if (life <= 0f)
        {
            InDeath();
        }
    }

    void InDeath()
    {
        Destroy(gameObject);
    }
    
}
