using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_positiion_Direct : MonoBehaviour
{
    private Vector3 _movePosition;
    public void SetMovePosition(Vector3 movePosition)
    {
        _movePosition = movePosition;
    }
    void Update()
    {
        Vector3 moveDir = (_movePosition - transform.position).normalized;
        GetComponent<IMove_Velocity>().SetVelocity(moveDir);
    }
}
