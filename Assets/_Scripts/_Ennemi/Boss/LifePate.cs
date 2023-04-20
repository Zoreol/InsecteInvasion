using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePate : MonoBehaviour
{
    [SerializeField] public float life;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mantis") && collision.GetComponent<UnityManager>().inAttack)
        {
                life--;
                if (life <= 0)
                {
                    Destroy(this.gameObject);
                }
      
            
        }
    }
}
