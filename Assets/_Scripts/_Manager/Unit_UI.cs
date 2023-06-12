using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Unit_UI : MonoBehaviour
{
    [SerializeField] private Liste_Mante _lm;
    [SerializeField] private List<GameObject> _visual_List = new List<GameObject>();
    [SerializeField] private Sprite[] _sprite;
    // On recupère dans un tableau les différents visuel de mante 

    public GameObject[] visualUnits;

    // On récupère le parents qui affichera les unité 
    public GameObject parentUnits;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        VisualMissing();
        AffichageRightUnit();
        if (Input.GetKeyUp(KeyCode.F))
            {
            CreateVisuel(visualUnits[0], parentUnits);
        }
    }

    // Fonction pour créer le visuel

    public void CreateVisuel(GameObject visualToDisplay, GameObject parent)
    {
        GameObject unitsVis = Instantiate(visualToDisplay, parent.transform);
        Button unitsSuppButton = unitsVis.GetComponentInChildren<Button>();
        Debug.Log(unitsSuppButton);
        unitsSuppButton.onClick.AddListener(SuppVisuel);
        _visual_List.Add(unitsVis);
    }

    // Fonction pour supprimer le visuel

    void SuppVisuel()
    {
        // On récupère le bouton qui vient d'être appuyé pour récupérer son parent et le supprimer
        GameObject buttonSelected = EventSystem.current.currentSelectedGameObject;
        Debug.Log(buttonSelected.transform.parent.ToString());
        Destroy(buttonSelected.transform.parent.gameObject);
        
        
    }
    void VisualMissing()
    {
        for (int i = 0; i < _visual_List.Count; i++)
        {
            if(_visual_List[i] == null)
            {
                Destroy(_lm.mantes[i].gameObject);
                _visual_List.RemoveAt(i);
            }
        }
    }
    void AffichageRightUnit()
    {
        for (int i = 0; i < _lm.mantes.Count; i++)
        {
            if(_lm.mantes[i].tag == "Recolteuse" && _lm.mantes[i].GetComponent<Animator_Change>().Changed_Sprite == false)
            {
                _visual_List[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = _sprite[0];
                _lm.mantes[i].GetComponent<Animator_Change>().Changed_Sprite = true;
            }
            if (_lm.mantes[i].tag == "Gendarme_Mante" && _lm.mantes[i].GetComponent<Animator_Change>().Changed_Sprite == false)
            {
                _visual_List[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = _sprite[1];
                _lm.mantes[i].GetComponent<Animator_Change>().Changed_Sprite = true;
            }
        }
    }
    
}
