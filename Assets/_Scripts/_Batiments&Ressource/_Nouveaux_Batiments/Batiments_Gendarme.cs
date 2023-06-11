using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batiments_Gendarme : MonoBehaviour
{
    [SerializeField] private float timerChange = 10;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timerChange -= Time.deltaTime;
            if (timerChange <= 0.5)
            {
                collision.gameObject.tag = "Gendarme_Mante";
                collision.gameObject.GetComponent<Navigation_NidPuceron>().enabled = true;
                collision.gameObject.GetComponentInChildren<Commune_Caracteristique_Mantis>()._maxHealth = 30;
                collision.gameObject.GetComponentInChildren<Commune_Caracteristique_Mantis>().health = 30;
                collision.gameObject.GetComponentInChildren<Commune_Caracteristique_Mantis>().damage = 2;
                timerChange = 10;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            timerChange = 10;
        }
    }
}
