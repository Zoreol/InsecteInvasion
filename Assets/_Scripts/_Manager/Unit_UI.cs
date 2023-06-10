using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Unit_UI : MonoBehaviour
{
    // On recup�re dans un tableau les diff�rents visuel de mante 

    [SerializeField] private GameObject[] visualUnits;

    // On r�cup�re le parents qui affichera les unit� 
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

    // Fonction pour cr�er le visuel

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
        GameObject buttonSelected = EventSystem.current.currentSelectedGameObject;
        Debug.Log(buttonSelected.transform.parent.ToString());
        Destroy(buttonSelected.transform.parent.gameObject);
        
        
    }
}
