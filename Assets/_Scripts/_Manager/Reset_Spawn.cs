using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Spawn : MonoBehaviour
{
    //public GameObject
    void Update()
    {
        
        if(transform.localPosition.y < -22f)
        {
            //this.transform.position = new Vector3(-20, 20, transform.position.z);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 40, transform.localPosition.z);
        }
    }
}
