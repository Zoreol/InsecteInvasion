using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityManager : MonoBehaviour
{
    [Header("Unit Settings")]
    [SerializeField] public float life;
    [SerializeField] float maxLife;
    [SerializeField] float attack;
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
        ForDeplacement();
    }
    public void InDeplacement(Vector2 nouvellePositionCible)
    {
        positionCible = nouvellePositionCible;
    }
    void ForDeplacement()
    {
        // Calcule la direction vers la cible
        Vector2 direction = positionCible - (Vector2)transform.position;

        // V�rifie si l'objet est arriv� � la cible
        if (direction.magnitude < 0.1f)
        {
            if (PlayerTarget && canAttack)
            {
                InFormation = true;
            }
            return;
        }
        else
        {
            InFormation = false;
        }

        // Normalise la direction et multiplie par la vitesse
        Vector2 movement = direction.normalized * speed * Time.deltaTime;

        // D�place l'objet dans la direction de la cible
        transform.Translate(movement, Space.World);

    }

    public void InAttack()
    {
        if (canAttack && InFormation && PlayerTarget && !attackingEnnemi)
        {
            StartCoroutine(OnAttackEnnemi());
        }
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
