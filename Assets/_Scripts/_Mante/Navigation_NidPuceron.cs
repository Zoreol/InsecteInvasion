using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation_NidPuceron : MonoBehaviour
{
    [SerializeField] private GameObject _skin_Recolteuse;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject nid1;
    [SerializeField] private GameObject baseposition;
    public bool Possede_puceron;
    public bool Recolte;
    public bool Mante_Recolteuse = false;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        nid1 = GameObject.Find("Nid_Puceron");
        baseposition = GameObject.Find("batiment_recolte");
    }
    private void OnEnable()
    {
        Mante_Recolteuse = true;
    }
    private void Update()
    {
        RecolteNidPuceron();
        ChangeSkin();
    }
    void RecolteNidPuceron()
    {
        if (Recolte)
        {
            navMeshAgent.SetDestination(nid1.transform.position);
        }
        if (Recolte && Possede_puceron)
        {
            navMeshAgent.SetDestination(baseposition.transform.position);
        }
    }
    void ChangeSkin()
    {
        if(this.tag == "Recolteuse")
        {
            //Debug.Log(transform.GetChild(3));
            transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
            _skin_Recolteuse.SetActive(true);
        }
    }
}
