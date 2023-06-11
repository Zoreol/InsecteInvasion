using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation_NidPuceron : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject nid1;
    [SerializeField] private GameObject baseposition;
    public bool Possede_puceron;
    public bool Recolte;
    public bool Mante_Recolteuse = false;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void OnEnable()
    {
        Mante_Recolteuse = true;
    }
    private void Update()
    {
        RecolteNidPuceron();
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
}
