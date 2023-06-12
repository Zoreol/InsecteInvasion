using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liste_Mante : MonoBehaviour
{
    public List<GameObject> mantes = new List<GameObject>();
    private void Update()
    {
        DestoryUnits();
    }
    void DestoryUnits()
    {
        if (Input.GetKey(KeyCode.S))
        {
            for (int i = 0; i < mantes.Count; i++)
            {
                Destroy(mantes[i].gameObject);
            }
            mantes.Clear();
        }
    }
}
    
