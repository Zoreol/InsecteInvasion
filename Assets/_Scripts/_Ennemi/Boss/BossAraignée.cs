using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAraignée : MonoBehaviour
{

    [SerializeField] public float life;
    [SerializeField] public float maxLife;
    [SerializeField] int Cooldown;
    [SerializeField] List<GameObject> unitMantisList;
    [SerializeField] bool wantAttack;
    [SerializeField] bool wantAttackBase;
    [SerializeField] bool wantAttackAway;
    [SerializeField] GameObject silk;
    [SerializeField] Animator animator;
    [SerializeField] public List<Animator> pawAnimator;

    private bool canRandom = true;
    int randomAttack;
    bool nullPaw;

    private void Start()
    {
        life = maxLife;
        for (int i = 0; i < pawAnimator.Count; i++)
        {
            pawAnimator[i].GetComponent<LifeForDestruction>().baseSpider = this;
        }
    }
    private void Update()
    {
        if (canRandom && !nullPaw)
        {
            canRandom = false;
            StartCoroutine(CooldownAttack());
        }
    }

    IEnumerator CooldownAttack()
    {

        yield return new WaitForSeconds(Cooldown);

        randomAttack = Random.Range(0, 20);
        print(randomAttack);
        if (randomAttack <= 14)
        {
            AttackAway();
        }
        else
        {
            ZoneAttackBack();
        }
    }
    
        
    void AttackAway()
    {
        animator.SetTrigger("DistanceAttack");

            for (int i = 0; i < unitMantisList.Count; i++)
            {
                GameObject SilkTargetPlayer = Instantiate(silk, transform.position, Quaternion.identity);
                SilkTargetPlayer.GetComponent<SilkManager>().positionCible = unitMantisList[0].transform.position;
                SilkTargetPlayer.transform.localScale = new Vector2(SilkTargetPlayer.transform.localScale.x * 4, SilkTargetPlayer.transform.localScale.y * 4);
            }
            
        canRandom = true;

    }
    void ZoneAttackBack()
    {
        for (int y = 0; y < pawAnimator.Count; y++)
        {
            pawAnimator[y].SetTrigger("PawAttack");
        }
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
            unitMantisList[i].GetComponent<UnityManager>().life -= 1f;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mantis"))
        {
            Hitdamage(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mantis"))
        {
            unitMantisList.Remove(collision.gameObject);
        }
    }
    public void VerifPaw()
    {
        if (pawAnimator.Count == 0)
        {
            nullPaw = true;
        }
    }
    void Hitdamage(Collider2D collision)
    {
        if (collision.GetComponent<UnityManager>().attackingEnnemi && nullPaw)
        {
            if (life>= 0)
            {
                life--;
                if (life <= 0)
                {
                    StartCoroutine(DestroyBoss());
                }
                animator.SetTrigger("Hit");
            }
        }
    }

    IEnumerator DestroyBoss()
    {
        animator.SetTrigger("Dead");
        this.GetComponent<BoxCollider2D>().enabled = false;

        float timeAnimDeadBoss = 7f;
        yield return new WaitForSeconds(timeAnimDeadBoss);

        SceneManager.LoadScene("Fin");
        Destroy(this.gameObject);
    }
    
}
