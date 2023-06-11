using NavMeshPlus.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NidPuceron : MonoBehaviour
{
    // detection des mantes Récolteuse a proximité
    [SerializeField] private List<GameObject> mante_Recolteuse = new List<GameObject>();
    //ajout timer pour la recolte de puceron
    [SerializeField] private float timer_Recolte_Puceron = 3;

    private int nbPuceronMax;
    private int nbPuceronMin;

    public int nbPuceron;

    private int nbPuceronVisible = 5;

    // Variable pour le timer d'apparition
    private float timer;

    // Temps limite entre chaque apparition
    private float waitTill = 2;

    private int addPuceron = 5;

    // Prefab de puceron
    [SerializeField] private GameObject puceronPrefab;

    // Verification d'apparition de puceron

    private bool puceronVisible = false;

    private bool canMove = true;

    // On crée un list pour stocker mles pucerons 

    private List<GameObject> eachPuceron = new List<GameObject>();

    // 

    void Start() {

        // On définit les valeurs min et max que peut contenir un nid 
        nbPuceronMin = 10;
        nbPuceronMax = 100;

        // On définit à la création du nid combien de temps il faut pour créer de nouvelles ressources
        waitTill = Random.Range(3, 10);

        // On définit un valeur de départ différente de chaque nid
        InitializeNid();

        
    }

    void Update()
    {

        timer += Time.deltaTime;


        // Quand le timer atteint les 5 secondes, on ajoute x pucerons
        if (timer >= waitTill) {

            if (nbPuceron + addPuceron  < 100)
            {
                AddWithTime(addPuceron);
                
            }
            else
            {
                timer = 0;
                return;
            }
            
        }

        // S'il y a plus de 0 puceron
        if (nbPuceron > 0)
        {
            // S'il n'y a pas de puceron déjà visible 
            if (puceronVisible == false)
            {
                //Alors on instancie un groupe de puceron 

                for (int i = 0; i < nbPuceronVisible; i++)
                {
                    CreatePuceron();
                }
                // On retourne vrai pour la visibilité des pucerons
                puceronVisible = true;
            }

            else if (puceronVisible ==true & canMove == true) {
                
                TranslatePuceron();

                
                

                
            }

            else
            {
                return;
            }           
           
        }
        else
        {
            // Si les pucerons sont 0

             // Alors on détruit tout les pucerons dans le tableau
            foreach (GameObject obj in eachPuceron)
            {
                
                Destroy(obj);
            }

            eachPuceron.Clear();
            //On retourne faux pour la visibilité des pucerons
            puceronVisible = false;
        }
        
    }

     void InitializeNid()
    {

        nbPuceron = Random.Range(nbPuceronMin, nbPuceronMax);

    }

    void AddWithTime(int addPuceron)
    {

        nbPuceron += addPuceron;

        // On reboot le timer
        timer = 0;

        

    }

    void CreatePuceron()
    {
        GameObject objPuceron = Instantiate(puceronPrefab, this.transform.position,  new Quaternion(0, 0, Random.Range(0, 360),0), this.transform) as GameObject;
        objPuceron.AddComponent<NavMeshAgent>();
        objPuceron.AddComponent<AgentOverride2d>();
        objPuceron.AddComponent<AgentRotate2d>();
        
        eachPuceron.Add(objPuceron);

        canMove = true;
        
        
    }

    void TranslatePuceron()
    {
        canMove =false;
        if (eachPuceron.Count > 0)
        {
                for (int i = 0; i < eachPuceron.Count; i++)
             {
            
            // On récupère un point aléatoirement dans un cercle
            Vector2 posCircle = Random.insideUnitCircle.normalized *10;
            
            Vector3 destination_puceron = this.transform.position + new Vector3(posCircle.x , posCircle.y , 1);
            
            
            
            // On attribue la destination de chaque navmesh
            eachPuceron[i].GetComponent<NavMeshAgent>().SetDestination(destination_puceron );
                




            //On patiente avant de relancer un mouvement 
            StartCoroutine("Wait");
            
             }
           


            }

        else { return; }       
        
    }

    IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(10);
        
        canMove = true;
    }


    //ajout de la mante a la liste
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Recolteuse")
        {
            mante_Recolteuse.Add(collision.gameObject);
            for (int i = 0; i < mante_Recolteuse.Count; i++)
            {
                mante_Recolteuse[i].GetComponent<Navigation_NidPuceron>().Recolte = true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //si la liste est a 0 on renvoie pour ne pas faire d erreur
        if(mante_Recolteuse.Count <= 0)
        {
            return;
        }
        //si la mante n'a rien recolté elle attend puis récolte et est retirer de la liste de recolte
        else if(collision.tag == "Recolteuse" && mante_Recolteuse[0].GetComponent<Navigation_NidPuceron>().Possede_puceron == false)
        {
            timer_Recolte_Puceron -= Time.deltaTime;
            if(timer_Recolte_Puceron <= 0)
            {
                mante_Recolteuse[0].GetComponent<Navigation_NidPuceron>().Possede_puceron = true;
                nbPuceron = nbPuceron - 5;
                timer_Recolte_Puceron = 3;
                mante_Recolteuse.Remove(collision.gameObject);
            }
        }
        // si elle a deja recolté mais qu'elle re rentre elle est ejecter de la liste car elle possede deja des puceron
        else if(collision.tag == "Recolteuse" && mante_Recolteuse[0].GetComponent<Navigation_NidPuceron>().Possede_puceron == true)
        {
            mante_Recolteuse.Remove(collision.gameObject);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Recolteuse")
        {
            mante_Recolteuse.Remove(collision.gameObject);
        }
    }


}

