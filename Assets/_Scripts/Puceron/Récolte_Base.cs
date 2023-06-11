using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Récolte_Base : MonoBehaviour
{
    [SerializeField] private List<GameObject> recolteuse = new List<GameObject>();
    [SerializeField]  private float time_unload = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Recolteuse")
        {
            recolteuse.Add(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(recolteuse.Count <= 0)
        {
            return;
        }

        else if(recolteuse[0].GetComponent<Navigation_NidPuceron>().Possede_puceron == false)
        {
            recolteuse.Remove(collision.gameObject);
            return;
        }
        else if(collision.tag == "Recolteuse" && recolteuse[0].GetComponent<Navigation_NidPuceron>().Possede_puceron == true)
        {
            if (time_unload <=0.5)
            {
                recolteuse[0].GetComponent<Navigation_NidPuceron>().Possede_puceron = false;
                recolteuse.Remove(collision.gameObject);
                time_unload = 3;

                // add 5 aux ressource
            }
        }
        if(collision.tag == "Recolteuse" && recolteuse.Count > 0)
        {

            time_unload -= Time.deltaTime;
        }
    }
}
