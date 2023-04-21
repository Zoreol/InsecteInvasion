using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi_Identification : MonoBehaviour
{
    [SerializeField] private GameObject _selected_GameObject;

    private void Awake()
    {
        SetSelectedVisible(false);
    }
    public void SetSelectedVisible(bool visible)
    {
        if(_selected_GameObject != null)
        {
            _selected_GameObject.SetActive(visible);
        }
    }
}
