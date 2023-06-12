using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Unit_UI : MonoBehaviour
{
    [SerializeField] private Liste_Mante lm;
    // On recupère dans un tableau les différents visuel de mante 

    [SerializeField] private GameObject[] visualUnits;

    // On récupère le parents qui affichera les unité 
    [SerializeField] private GameObject parentUnits;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
            {
            CreateVisuel(visualUnits[0], parentUnits);
        }
    }

    // Fonction pour créer le visuel

    void CreateVisuel(GameObject visualToDisplay, GameObject parent)
    {
        GameObject unitsVis = Instantiate(visualToDisplay, parent.transform);
        Button unitsSuppButton = unitsVis.GetComponentInChildren<Button>();
        Debug.Log(unitsSuppButton);
        unitsSuppButton.onClick.AddListener(SuppVisuel);
    }

    // Fonction pour supprimer le visuel

    void SuppVisuel()
    {
        // On récupère le bouton qui vient d'être appuyé pour récupérer son parent et le supprimer
        GameObject buttonSelected = EventSystem.current.currentSelectedGameObject;
        Debug.Log(buttonSelected.transform.parent.ToString());
        Destroy(buttonSelected.transform.parent.gameObject);
        
        
    }
    
}
