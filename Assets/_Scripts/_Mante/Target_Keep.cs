using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Keep : MonoBehaviour
{
    public Selection select;
    public Unit_Identification unit_identification;
    public GameObject _ennemi_to_keep;
    private void Awake()
    {
        select = FindObjectOfType<Selection>();
    }
    private void Update()
    {
        KeepEnnemi();
    }
    void KeepEnnemi()
    {
        if(select._selected_ennemi_List.Count > 0 && unit_identification.is_selected)
        {
            _ennemi_to_keep = select._selected_ennemi_List[0].gameObject;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ennemi" && _ennemi_to_keep != null)
        {
            //Attack mode
            Debug.Log("Attack");
        }
    }
}
