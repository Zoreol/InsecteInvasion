using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAraignée : MonoBehaviour
{
    [SerializeField] int Cooldown;
    [SerializeField] List<GameObject> unitMantisList;
    [SerializeField] bool wantAttack;
    [SerializeField] bool wantAttackBase;
    [SerializeField] bool wantAttackAway;

    private bool inAttack;
    private bool canRandom = true;
    int randomAttack;
    private void Update()
    {
        if (canRandom)
        {
            canRandom = false;
            StartCoroutine(CooldownAttack());
        }/*
        if (wantAttack)
        {
            ZoneAttackBack();
        }
        if (wantAttackBase)
        {
            StartCoroutine(AttackBase());
        }
        if (wantAttackAway)
        {
            StartCoroutine(AttackAway());
        }*/
    }

    IEnumerator CooldownAttack()
    {

        yield return new WaitForSeconds(Cooldown);

        randomAttack = Random.Range(0, 3);
        if (randomAttack == 0)
        {
            StartCoroutine(AttackBase());
        }
        if (randomAttack == 1)
        {
            StartCoroutine(AttackAway());
        }
        if (randomAttack == 2)
        {
            ZoneAttackBack();
        }
    }
    IEnumerator AttackBase()
    {
        if (!inAttack)
        {
            
            for (int i = 0; i < unitMantisList.Count; i++)
            {
                if (Vector2.Distance(this.gameObject.transform.position, unitMantisList[i].transform.position) <= 3.5f && !inAttack)
                {
                    

                    yield return new WaitForSeconds(3f);

                    inAttack = true;
                    unitMantisList[i].GetComponent<UnityManager>().life -= 2f;

                }
                
            }
            inAttack = false;
            canRandom = true;
        }
        
    }
    IEnumerator AttackAway()
    {
        if (!inAttack)
        {

            for (int i = 0; i < unitMantisList.Count; i++)
            {
                if (!inAttack)
                {
                    
                    yield return new WaitForSeconds(3f);

                    inAttack = true;
                    unitMantisList[i].GetComponent<UnityManager>().life -= 1f;
                }

            }
            inAttack = false;
            canRandom = true;
        }

    }
    void ZoneAttackBack()
    {
        for (int i = 0; i < unitMantisList.Count; i++)
        {
            //paramettre position du boss et des manthes
            Vector2 unitMantis = new Vector2(unitMantisList[i].transform.position.x, unitMantisList[i].transform.position.y);
            Vector2 unitBoss = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            // Calcule la direction vers la cible
            Vector2 direction = unitMantis - unitBoss;

            // Normalise la direction et multiplie par la vitesse
            Vector2 movement = direction.normalized * 15 * Time.deltaTime;

            // Déplace l'objet dans la direction de la cible
            unitMantisList[i].transform.Translate(movement/2, Space.World);
        }
        canRandom = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mantis"))
        {
            unitMantisList.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mantis"))
        {
            unitMantisList.Remove(collision.gameObject);
            if (unitMantisList.Count == 0)
            {
                Debug.Log("je rentre");
            }
        }
    }
    
}
