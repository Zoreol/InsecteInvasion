using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NidPuceron : MonoBehaviour
{
    private int nbPuceronMax;
    private int nbPuceronMin;

    public int nbPuceron;

    private int nbPuceronVisible = 5;

    // Variable pour le timer d'apparition
    private float timer;
    private float limitTimer;

    // Temps limite entre chaque apparition
    private float waitTill = 2;

    private int addPuceron = 5;

    // Prefab de puceron
    [SerializeField] private GameObject puceronPrefab;

    // Verification d'apparition de puceron

    private bool puceronVisible = false;

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

            else {
                //StartCoroutine("Wait");
                
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

            //On retourne faux pour la visibilité des pucerons
            puceronVisible = false;
        }

        while (puceronVisible == true)
        {
            StartCoroutine("Wait");
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
        GameObject obj = Instantiate(puceronPrefab, this.transform.position,  new Quaternion(0, 0, Random.Range(0, 360),0), this.transform) as GameObject;
        eachPuceron.Add(obj);
    }

    void TranslatePuceron(int radiusCircle)
    {
        
        foreach (GameObject obj in eachPuceron)
        {
            Vector3 posInCircle = Random.insideUnitSphere;
            
            obj.transform.Translate( new Vector3 (posInCircle.x, posInCircle.y,this.transform.position.z) * radiusCircle);

            obj.transform.rotation = Quaternion.LookRotation(Vector3.forward, posInCircle);
        }

        
    }

    IEnumerator Wait()
    {
        TranslatePuceron(5);
        yield return new WaitForSeconds(5);
        Debug.Log("recall");
    }
}

