using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Identification : MonoBehaviour
{
    private GameObject _selected_GameObject;
    private void Awake()
    {
        _selected_GameObject = transform.Find("Selected").gameObject;
        SetSelectedVisible(false);
    }

    public void SetSelectedVisible(bool visible)
    {
        _selected_GameObject.SetActive(visible);
    }
}
