using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit_Identification : MonoBehaviour
{
    [SerializeField]private GameObject _selected_GameObject;
    //public GameObject _spawn_Direction;
    public NavMeshAgent agent;
    public bool is_selected = false;
    public Target_Keep tk;
    private void Awake()
    {
        SetSelectedVisible(false);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //agent.SetDestination(_spawn_Direction.transform.position);
        //_spawn_Direction.transform.position = new Vector3(_spawn_Direction.transform.position.x + 2f, _spawn_Direction.transform.position.y , _spawn_Direction.transform.position.z);
    }
    private void Update()
    {
        FollowingTarget();
    }
    public void SetSelectedVisible(bool visible)
    {
        _selected_GameObject.SetActive(visible);
        is_selected = visible;
    }
    private void FollowingTarget()
    {
        if(tk._ennemi_to_keep != null)
        {
            agent.SetDestination(tk._ennemi_to_keep.transform.position);
        }
    }
    
}
