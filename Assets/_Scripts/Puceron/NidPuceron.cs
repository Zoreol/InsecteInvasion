using NavMeshPlus.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NidPuceron : MonoBehaviour
{
    private int nbPuceronMax;
    private int nbPuceronMin;

    public int nbPuceron;

    private int nbPuceronVisible = 5;

    // Variable pour le timer d'apparition
    private float timer;
    private float limitTimer;

    [SerializeField] private float speedPuceron = 5;

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
        //objPuceron.GetComponent<NavMeshAgent>().areaMask = NavMesh.GetAreaFromName("Walkable");
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
            
            Vector3 Destination_puceron = this.transform.position + new Vector3(posCircle.x , posCircle.y , 1);
            
            eachPuceron[i].transform.position = new Vector3(eachPuceron[i].transform.position.x, eachPuceron[i].transform.position.y, 1);
            
            // On attribue la destination de chaque navmesh
            eachPuceron[i].GetComponent<NavMeshAgent>().SetDestination(Destination_puceron );
            
            //On patiente avant de relancer un mouvement 
            StartCoroutine("Wait");
            
             }


        }

        else { return; }       
        
    }

    IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(10);
        Debug.Log("recall");
        canMove = true;
    }

    void UpdateAnimation()
    {
        
    }


}

