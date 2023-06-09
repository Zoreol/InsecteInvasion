using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityManager : MonoBehaviour
{
    [Header("Unit Settings")]
    public Animator animUnit;
    [SerializeField] public float life;
    [SerializeField] public float maxLife;
    [SerializeField] public float attack;
    [SerializeField] public float speed;
    [SerializeField] bool canAttack;
    [SerializeField] public bool inAttack;
    [SerializeField] public bool InFormation;
    [SerializeField] public bool PlayerTarget;
    public Vector2 positionCible;
    public bool attackingEnnemi;

    private void Start()
    {
        life = maxLife;
    }
    private void Update()
    {
        //ForDeplacement();
        if (InFormation)
        {
            animUnit.SetTrigger("Attack");
            
        }
        
    }
    public void InDeplacement(Vector2 nouvellePositionCible)
    {
        positionCible = nouvellePositionCible;
    }
    void ForDeplacement()
    {
        // Calcule la direction vers la cible
        Vector2 direction = positionCible - (Vector2)transform.position;

        // Vérifie si l'objet est arrivé à la cible
        if (direction.magnitude < 0.1f)
        {
            if (!InFormation)
            {
                Debug.Log("Je marche plus");
                animUnit.SetTrigger("Idle");
            }
            else if (PlayerTarget && canAttack)
            {
                
                InFormation = true;
            }
            return;
            
        }
        else
        {
            Debug.Log("Je marche");
            animUnit.SetTrigger("Marche");
            InFormation = false;
        }

        // Normalise la direction et multiplie par la vitesse
        Vector2 movement = direction.normalized * speed * Time.deltaTime;

        // Déplace l'objet dans la direction de la cible
        transform.Translate(movement, Space.World);

    }

    public void InAttack()
    {
        if (canAttack && InFormation && PlayerTarget && !attackingEnnemi)
        {
            StartCoroutine(OnAttackEnnemi());
        }
    }
    public IEnumerator InStun()
    {
        float speedbase = speed;
        float attackbase = attack;
        speed = 0;
        attack = 0;
        inAttack = false;

        yield return new WaitForSeconds(3f);

        speed = speedbase;
        attack = attackbase;
        inAttack = true;
    }
    IEnumerator OnAttackEnnemi()
    {
        attackingEnnemi = true;
        gameObject.GetComponent<IAUnitManager>().Attack();

        yield return new WaitForSeconds(3f);

        attackingEnnemi = false;
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
