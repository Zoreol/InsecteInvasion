using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Mouvement : MonoBehaviour
{
    public Camera cam;
    [SerializeField] float speed;
    [SerializeField] float zoomspeed;
    public TutoManager tutoManager;


    bool firstmove = false;
    public bool firsscroll = false;
    private void Start()
    {
        tutoManager.textTuto.text = tutoManager.tutoPanel[0].textEtapeTuto;
    }
    private void Update()
    {
        MouveCamera();
        ZoomCamera();
    }
    void ZoomCamera()
    {
        if (cam.orthographic)
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoomspeed;
            if(cam.orthographicSize < 20)
            {
                if (!firsscroll)
                {
                    firsscroll = true;

                    tutoManager.textTuto.text = tutoManager.tutoPanel[2].textEtapeTuto;
                }
                cam.orthographicSize = 20;
            }
            if(cam.orthographicSize > 100)
            {
                if (!firsscroll)
                {
                    firsscroll = true;

                    tutoManager.textTuto.text = tutoManager.tutoPanel[2].textEtapeTuto;
                }
                cam.orthographicSize = 100;
            }
        }
    }
    void MouveCamera()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && cam.transform.position.x > -160f)
        {
            if (!firstmove)
            {
                firstmove = true;

                tutoManager.textTuto.text = tutoManager.tutoPanel[1].textEtapeTuto;
            }
            cam.transform.position = new Vector3(cam.transform.position.x - speed * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && cam.transform.position.x < 356)
        {
            if (!firstmove)
            {
                firstmove = true;

                tutoManager.textTuto.text = tutoManager.tutoPanel[1].textEtapeTuto;
            }
            cam.transform.position = new Vector3(cam.transform.position.x + speed * Time.deltaTime, cam.transform.position.y, cam.transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow) && cam.transform.position.y > -210f)
        {
            if (!firstmove)
            {
                firstmove = true;

                tutoManager.textTuto.text = tutoManager.tutoPanel[1].textEtapeTuto;
            }
            cam.transform.position = new Vector3(cam.transform.position.x , cam.transform.position.y - speed * Time.deltaTime, cam.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && cam.transform.position.y < 314)
        {
            if (!firstmove)
            {
                firstmove = true;

                tutoManager.textTuto.text = tutoManager.tutoPanel[1].textEtapeTuto;
            }
            cam.transform.position = new Vector3(cam.transform.position.x , cam.transform.position.y + speed * Time.deltaTime, cam.transform.position.z);
        }
    }
}
