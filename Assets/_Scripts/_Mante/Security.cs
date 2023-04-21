using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : MonoBehaviour
{
    
    private void Update()
    {
        if (this.transform.localPosition != Vector3.zero)
        {
            this.transform.localPosition = new Vector3(0,0,0);
        }
    }
}
