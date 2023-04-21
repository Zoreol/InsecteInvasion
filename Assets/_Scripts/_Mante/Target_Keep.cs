using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Target_Keep : MonoBehaviour
{
    public Selection select;
    public Unit_Identification unit_identification;
    public GameObject _ennemi_to_keep;
    [SerializeField] private Commune_Caracteristique_Mantis ccm;
    [SerializeField] private float _timer_attack;
    [SerializeField] private Animator anim;
    private void Awake()
    {
        select = FindObjectOfType<Selection>();
    }
    private void Update()
    {
        
        KeepEnnemi();
        if(_timer_attack > 0)
        {
            _timer_attack -= Time.deltaTime;
        }
        Debug.Log(_ennemi_to_keep);
    }
    void KeepEnnemi()
    {
        if(select._selected_ennemi_List != null)
        {
            if (select._selected_ennemi_List.Count > 0 && unit_identification.is_selected)
            {
                _ennemi_to_keep = select._selected_ennemi_List[0].gameObject;
                
            }
            
        }
        if(Input.GetMouseButtonDown(1) && select._selected_ennemi_List != null)
        {
            _ennemi_to_keep = null;
            anim.SetBool("Attack", false);
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == /*_ennemi_to_keep.tag*/ "Ennemi" && _ennemi_to_keep != null)
        {
            anim.SetBool("Attack", true);
            _ennemi_to_keep.GetComponent<IAUnitManager>().life = _ennemi_to_keep.GetComponent<IAUnitManager>().life - ccm.damage;
            _timer_attack = 2.5f;
        }
        else if (_ennemi_to_keep == null) 
        {
            anim.SetBool("Attack", false);
            return; 
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == /*_ennemi_to_keep.tag*/ "Ennemi" && _ennemi_to_keep != null && _timer_attack <= 0)
        {
            anim.SetBool("Attack", true);
            _ennemi_to_keep.GetComponent<IAUnitManager>().life = _ennemi_to_keep.GetComponent<IAUnitManager>().life - ccm.damage;
            _timer_attack = 2.5f;
        }
        else if (_ennemi_to_keep == null)
        {
            anim.SetBool("Attack", false);
            return;
        }
    }
}
