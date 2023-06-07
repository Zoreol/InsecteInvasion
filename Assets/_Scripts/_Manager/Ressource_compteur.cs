using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ressource_compteur : MonoBehaviour
{
    // Nb de ressource disponible 
    private int nbRessources = 0;

    [SerializeField] private TMP_Text compteur;
    void Start()
    {
        // Le compteur commence à 0
        nbRessources = 0;
    }

    // Fonction pour ajouter des ressources 
    public void CompteurRessources (int x)
    {
        // On ajoute X au compteur
        nbRessources += x;
        // On actualise le texte
        compteur.text = nbRessources.ToString();

    }
    


}
