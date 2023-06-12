using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ressource_compteur : MonoBehaviour
{
    // Nb de ressource disponible 
    public  int nbRessources = 0;

    [SerializeField] private TMP_Text compteur;

    // On récupère les sprite correspondant au garde manger 
    [SerializeField] private Sprite[] spriteGManger;

    // On récupère le sprite renderer pour le garde manger
    [SerializeField] private GameObject gardeMangerPrefab;

    //On prépare la variable sprite renderer
    private SpriteRenderer gMangerSRenderer;
    void Start()
    {
        // On récupère le sprite renderer 
        gMangerSRenderer = gardeMangerPrefab.GetComponent<SpriteRenderer>();
        // Le compteur commence à 0
        nbRessources = 15;
    }
    private void Update()
    {
        

        UpdateSprite();
    }

    // Fonction pour ajouter des ressources 
    public void CompteurRessources (int x)
    {
        // On ajoute X au compteur
        nbRessources += x;
        // On actualise le texte
        compteur.text = nbRessources.ToString();

    }

    // Fonction pour qu'à chaque palier de nb de ressource atteint, le visuel change
    void UpdateSprite()
    {
        if (nbRessources <= 0)
        {
            gMangerSRenderer.sprite = spriteGManger[0];
        }
        else if(nbRessources > 0 && nbRessources <= 15)
        {
            gMangerSRenderer.sprite = spriteGManger[1];
        }
        else if (nbRessources > 15 && nbRessources <= 30)
        {
            gMangerSRenderer.sprite = spriteGManger[2];
        }
        else
        {
            gMangerSRenderer.sprite = spriteGManger[3];
        }
    }


}
