using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeForDestruction : MonoBehaviour
{
    public BossAraignée baseSpider;
    [SerializeField] Animator animator;
    [SerializeField] GameObject partDestruction;
    [SerializeField] float life;
    private void OnTriggerStay2D(Collider2D collision)
    {
        //on capte ce qui nous interesse
        if (collision.CompareTag("Mantis"))
        {
             Hitdamage(collision);
        }
    }
    void Hitdamage(Collider2D collision)
    {
        //on voit si il attaque
        if (collision.GetComponent<UnityManager>().attackingEnnemi)
        {
            if (life >= 0)
            {
                life--;
                //verification si la patte n'est pas mourte
                if (life <= 0)
                {
                    //tu me retire de la liste la patte qui va mourrir
                    baseSpider.pawAnimator.Remove(animator);
                    //je regarde si toute mais pattes sont perdu si c'est le cas tu peut attaquer le corps
                    baseSpider.VerifPaw();
                    //Supprime ma patte
                    StartCoroutine(DestroyPaw());
                }
                    animator.SetTrigger("Hit");
                
            }
        }
    }

    IEnumerator DestroyPaw()
    {
        animator.SetTrigger("Dead");

        this.GetComponent<BoxCollider2D>().enabled = false;

        float timeAnimDeadBoss = 5f;
        yield return new WaitForSeconds(timeAnimDeadBoss);

        Destroy(this.gameObject);
    }
}
