using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAraignée : MonoBehaviour
{
    [SerializeField] List<GameObject> unitMantisList;


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
