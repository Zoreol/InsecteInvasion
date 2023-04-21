using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Mouvement : MonoBehaviour
{
    public Camera cam;
    void MouveCamera()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            cam.transform.position = new Vector3(cam.transform.position.x - 10 * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            cam.transform.position = new Vector3(cam.transform.position.x + 10 * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            cam.transform.position = new Vector3(cam.transform.position.x , cam.transform.position.y - 10 * Time.deltaTime, cam.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            cam.transform.position = new Vector3(cam.transform.position.x , cam.transform.position.y + 10 * Time.deltaTime, cam.transform.position.z);
        }
    }
}
