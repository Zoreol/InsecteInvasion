using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Position : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public void GetMouseWorldPosition()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane + 1;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
    }
}
