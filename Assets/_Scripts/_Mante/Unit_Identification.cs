using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit_Identification : MonoBehaviour
{
    [SerializeField]private GameObject _selected_GameObject;
    public NavMeshAgent agent;
    private void Awake()
    {
        SetSelectedVisible(false);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void SetSelectedVisible(bool visible)
    {
        _selected_GameObject.SetActive(visible);
    }
}
