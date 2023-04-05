using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClic : MonoBehaviour
{
    [SerializeField] private Mouse_Position _mouse_Position;
    void Start()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _mouse_Position.GetMouseWorldPosition();
            GetComponent<Move_positiion_Direct>().SetMovePosition(_mouse_Position.worldPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
