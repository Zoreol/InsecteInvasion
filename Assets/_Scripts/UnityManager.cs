using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityManager : MonoBehaviour
{
    //base script Unit parametre
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

    protected bool TakingDamage;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        ///donne de la vie
        life = maxLife;
    }
    private void Update()
    {
        //deplacement
        ForDeplacement();
        //si je suis en formation j'attack
        if (InFormation)
        {
            animUnit.SetTrigger("Attack");
        }
        
    }
    public void InDeplacement(Vector2 nouvellePositionCible)
    {
        //quand j'ai une nouvelle position je vais la bas
        positionCible = nouvellePositionCible;
    }
    void ForDeplacement()
    {
        if (InFormation && PlayerTarget) return;
        // Calcule la direction vers la cible
        Vector2 direction = positionCible - (Vector2)transform.position;

        // Vérifie si l'objet est arrivé à la cible
        if (direction.magnitude < 0.1f)
        {
            if (!InFormation)
            {
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
            animUnit.SetTrigger("Marche");
            
            InFormation = false;
        }

        // Normalise la direction et multiplie par la vitesse
        Vector2 movement = direction.normalized * speed * Time.deltaTime;

        // Déplace l'objet dans la direction de la cible
        transform.Translate(movement, Space.World);

        //rotation en fonction de la direction
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);

    }

    public void InAttack()
    {
        //si tout mes parametre je peux attacker
        if (canAttack && InFormation && PlayerTarget && !attackingEnnemi)
        {
            StartCoroutine(OnAttackEnnemi());
        }
    }
    public IEnumerator InStun()
    {
        //quand je suis stun
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
        //donne un cooldown a chaque attaque
        attackingEnnemi = true;
        gameObject.GetComponent<IAUnitManager>().Attack();

        yield return new WaitForSeconds(3f);

        attackingEnnemi = false;
    }
    public IEnumerator TakeDamage()
    {
        //prend des degats
        animUnit.SetBool("Touche",true);
        life--;
            yield return new WaitForSeconds(0.5f);
        
        if (life <= 0f)
        {
            StartCoroutine(InDeath());
        }
        animUnit.SetBool("Touche", false);
        TakingDamage = false;
    }

    IEnumerator InDeath()
    {
        //meurt
        animUnit.SetTrigger("Mort");

        yield return new WaitForSeconds(1.2f);

        Destroy(gameObject);
    }
    
}
