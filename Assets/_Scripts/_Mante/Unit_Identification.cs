using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit_Identification : MonoBehaviour
{
    [SerializeField]private GameObject _selected_GameObject;
    [SerializeField]private GameObject _spawn_Direction;
    public NavMeshAgent agent;
    private void Awake()
    {
        _spawn_Direction = GameObject.FindGameObjectWithTag("Spawn_Ville_Base");
        SetSelectedVisible(false);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(_spawn_Direction.transform.position);
        _spawn_Direction.transform.position = new Vector3(_spawn_Direction.transform.position.x + 1.5f, _spawn_Direction.transform.position.y , _spawn_Direction.transform.position.z);
    }
    public void SetSelectedVisible(bool visible)
    {
        _selected_GameObject.SetActive(visible);
    }
}
