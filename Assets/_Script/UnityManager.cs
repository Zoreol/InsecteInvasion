using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityManager : MonoBehaviour
{
    [Header("Unit Settings")]
    [SerializeField] public float life;
    [SerializeField] public bool inDeplacementCondition;
    [SerializeField] float maxLife;
    [SerializeField] float attack;
    [SerializeField] public float speed;
    [SerializeField] bool canAttack;

    public Vector2 positionCible;

    private void Start()
    {
        inDeplacementCondition = false;
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

    public void InAttack()
    {
        if (canAttack)
        {

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
