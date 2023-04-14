using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Spawn : MonoBehaviour
{
    //public GameObject
    void Update()
    {
        
        if(transform.position.y < (transform.position.y - 40f))
        {
            //this.transform.position = new Vector3(-20, 20, transform.position.z);
        }
    }
}
