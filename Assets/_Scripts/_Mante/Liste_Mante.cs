using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liste_Mante : MonoBehaviour
{
    public List<GameObject> mantes = new List<GameObject>();
    [SerializeField] private Unit_UI _unit_UI;
    private int _actual_mante_number= 0;
    private void Update()
    {
        AffichageMante();
        DestoryUnits();
    }
    void DestoryUnits()
    {
        /*if (Input.GetKey(KeyCode.S))
        {
            for (int i = 0; i < mantes.Count; i++)
            {
                Destroy(mantes[i].gameObject);
            }
            mantes.Clear();
        }*/
    }
    void AffichageMante()
    {
        if(_actual_mante_number != mantes.Count)
        {
            _unit_UI.CreateVisuel(_unit_UI.visualUnits[0], _unit_UI.parentUnits);
            _actual_mante_number = mantes.Count;
        }
    }
}
    
