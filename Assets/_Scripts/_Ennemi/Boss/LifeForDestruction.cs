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
        if (collision.CompareTag("Mantis"))
        {
             Hitdamage(collision);
        }
    }
    void Hitdamage(Collider2D collision)
    {
        if (collision.GetComponent<UnityManager>().attackingEnnemi)
        {
            if (life >= 0)
            {
                life--;
                if (life <= 0)
                {
                    baseSpider.pawAnimator.Remove(animator);
                    baseSpider.VerifPaw();
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

        float timeAnimDeadBoss = 2f;
        yield return new WaitForSeconds(timeAnimDeadBoss);

        Destroy(this.gameObject);
    }
}
