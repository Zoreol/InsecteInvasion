using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    [SerializeField] private Transform _selection_Area_Transform;
    [SerializeField] private Mouse_Position _mouse_Position;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private List<Unit_Identification> _selected_Unit_List;

    private void Awake()
    {
        _selected_Unit_List = new List<Unit_Identification>();
        _selection_Area_Transform.gameObject.SetActive(false);
    }
    void Update()
    {
        //Left Button pressed
        if (Input.GetMouseButtonDown(0))
        {
            _selection_Area_Transform.gameObject.SetActive(true);
            _mouse_Position.GetMouseWorldPosition();
            _startPosition = _mouse_Position.worldPosition;
        }
        if (Input.GetMouseButton(0))
        {

            _mouse_Position.GetMouseWorldPosition();
            Vector3 currentMousePosition = _mouse_Position.worldPosition;
            Vector3 lowerLeft = new Vector3(Mathf.Min(_startPosition.x, currentMousePosition.x), Mathf.Min(_startPosition.y, currentMousePosition.y));
            Vector3 upperRight = new Vector3(Mathf.Max(_startPosition.x, currentMousePosition.x), Mathf.Max(_startPosition.y, currentMousePosition.y));
            _selection_Area_Transform.position = lowerLeft;
            _selection_Area_Transform.localScale = upperRight - lowerLeft;
        }
        //Left Button released
        if (Input.GetMouseButtonUp(0))
        {

            _selection_Area_Transform.gameObject.SetActive(false);
            _mouse_Position.GetMouseWorldPosition();
            _endPosition = _mouse_Position.worldPosition;
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(_startPosition, _endPosition);
            //Deselect all units
            foreach(Unit_Identification unit_Identification in _selected_Unit_List)
            {
                unit_Identification.SetSelectedVisible(false);
            }
            _selected_Unit_List.Clear();
            //Select units within selection area
            foreach (Collider2D collider2D in collider2DArray)
            {
                Unit_Identification unit_Identification = collider2D.GetComponent<Unit_Identification>();
                if (unit_Identification != null)
                {
                    unit_Identification.SetSelectedVisible(true);
                    _selected_Unit_List.Add(unit_Identification);
                }
            }
            Debug.Log(_selected_Unit_List.Count);
        }
    }
}
