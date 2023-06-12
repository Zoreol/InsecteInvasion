using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batiments_Recolteuse : MonoBehaviour
{
    [SerializeField] private float timerChange = 10;
    [SerializeField] private Ressource_compteur rc;

    private void Awake()
    {
        rc = FindObjectOfType<Ressource_compteur>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            timerChange -= Time.deltaTime;
            if(timerChange <= 0.5 && rc.nbRessources >= 3)
            {
                collision.gameObject.tag = "Recolteuse";
                collision.gameObject.GetComponent<Navigation_NidPuceron>().enabled = true;
                collision.gameObject.GetComponentInChildren<Commune_Caracteristique_Mantis>()._maxHealth = 15;
                collision.gameObject.GetComponentInChildren<Commune_Caracteristique_Mantis>().health = 15;
                collision.gameObject.GetComponentInChildren<Commune_Caracteristique_Mantis>().damage = 0;
                rc.nbRessources = rc.nbRessources - 3;
                timerChange = 10;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            timerChange = 10;
        }
    }
}
