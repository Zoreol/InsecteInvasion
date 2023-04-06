using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Spawn : MonoBehaviour
{
    void Update()
    {
        if(transform.position.x > 15)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }
    }
}
