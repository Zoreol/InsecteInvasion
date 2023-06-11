using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrintCtrl : MonoBehaviour
{
    private Building_Datas _datas;
    private int _nbCollision = 1;
    private BoxCollider2D _collider2D;

    private void OnEnable()
    {
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Constructable"))
        {
            _nbCollision--;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Constructable"))
        {
            _nbCollision++;
        }
    }
    public bool IsConstructable()
    {
        if (_nbCollision > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
