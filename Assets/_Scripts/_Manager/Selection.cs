using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    [SerializeField] private Transform _selection_Area_Transform;
    [SerializeField] private Mouse_Position _mouse_Position;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    public List<Unit_Identification> _selected_Unit_List;
    public List<Ennemi_Identification> _selected_ennemi_List;
    public List<Ennemi_Identification> _last_ennemi = null;
    public Vector3 moveToPosition;
    public Vector3 moveToPositionsafe;

    //public bool firstSelection;
    //public bool firstdeplacement;
    //public bool firstattack;

    private void Awake()
    {
        _selected_Unit_List = new List<Unit_Identification>();
        _selected_ennemi_List = new List<Ennemi_Identification>();
        _selection_Area_Transform.gameObject.SetActive(false);
    }
    void Update()
    {
        if(_selected_ennemi_List.Count >0)
        {
            if (_selected_ennemi_List[0].gameObject.GetComponent<Death_destroy>().die == true)
            {
                _selected_ennemi_List.Clear();
            }
        }
        Unit_Selection_Mouvement();
        
    }
    private List<Vector3> GetPositionListAround(Vector3 startPosition, float[] ringDistanceArray, int[] ringPositionCountArray)
    {
        List<Vector3> positionList = new List<Vector3>();
        positionList.Add(startPosition);
        for (int i = 0; i < ringDistanceArray.Length; i++)
        {
            positionList.AddRange(GetPositionListAround(startPosition, ringDistanceArray[i], ringPositionCountArray[i]));
        }
        return positionList;
    }
    private List<Vector3> GetPositionListAround(Vector3 startPosition, float distance, int positionCount)
    {
        List<Vector3> positionList = new List<Vector3>();
        for (int i = 0; i < positionCount; i++)
        {
            float angle = i * (360f / positionCount);
            Vector3 dir = ApplyRotationToVector(new Vector3(1, 0), angle);
            Vector3 position = startPosition + dir * distance;
            positionList.Add(position);
        }
        return positionList;
    }
    private Vector3 ApplyRotationToVector(Vector3 vec, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * vec;
    }
    private void Unit_Selection_Mouvement()
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
            foreach (Unit_Identification unit_Identification in _selected_Unit_List)
            {
                unit_Identification.SetSelectedVisible(false);
            }
            _selected_Unit_List.Clear();
            foreach (Ennemi_Identification ennemi_Identification in _selected_ennemi_List)
            {
                ennemi_Identification.SetSelectedVisible(false);
            }
            _selected_ennemi_List.Clear();
            //Select units within selection area
            foreach (Collider2D collider2D in collider2DArray)
            {
                Unit_Identification unit_Identification = collider2D.GetComponent<Unit_Identification>();
                if (unit_Identification != null)
                {
                    unit_Identification.SetSelectedVisible(true);
                    _selected_Unit_List.Add(unit_Identification);
                    /*if (FindObjectOfType<Ville_Mante_Religieuse>().firstUnitPlace && !firstSelection)
                    {
                        firstSelection = true;
                        gameObject.GetComponent<Camera_Mouvement>().tutoManager.textTuto.text = gameObject.GetComponent<Camera_Mouvement>().tutoManager.tutoPanel[4].textEtapeTuto;
                    }*/
                    
                }
            }

        }
        if (Input.GetMouseButtonDown(1))
        {

            _mouse_Position.GetMouseWorldPosition();
            moveToPosition = _mouse_Position.worldPosition;
            

            /*List<Vector3> targetPositionList = GetPositionListAround(moveToPosition, new float[] { 2f, 4f, 6f }, new int[] { 5, 10, 15 });
            int targetPositionListIndex = 0;
            foreach (Unit_Identification unit_Identification in _selected_Unit_List)
            {
                unit_Identification.agent.SetDestination(targetPositionList[targetPositionListIndex]);
                targetPositionListIndex = (targetPositionListIndex + 1) % targetPositionList.Count;
            }*/
            _mouse_Position.GetMouseWorldPosition();
            _endPosition = _mouse_Position.worldPosition;
            if (_selected_ennemi_List.Count == 0)
            {
                moveToPosition = _mouse_Position.worldPosition;
            }
            else if (_selected_ennemi_List.Count > 0)
            {
                if(_selected_ennemi_List[0].gameObject != null)
                {
                    moveToPosition = _selected_ennemi_List[0].transform.position;
                    /*if (firstdeplacement && !firstattack)
                    {
                        firstattack = true;
                        gameObject.GetComponent<Camera_Mouvement>().tutoManager.textTuto.text = gameObject.GetComponent<Camera_Mouvement>().tutoManager.tutoPanel[6].textEtapeTuto;
                    }*/
                }
                
            }
            Collider2D[] collider2DArrayEnnemi = Physics2D.OverlapAreaAll(_startPosition, _endPosition);
            foreach (Ennemi_Identification ennemi_Identification in _selected_ennemi_List)
            {
                ennemi_Identification.SetSelectedVisible(false);
            }
            _selected_ennemi_List.Clear();
            //Select units within selection area
            foreach (Collider2D collider2D in collider2DArrayEnnemi)
            {
                Ennemi_Identification ennemi_Identification = collider2D.GetComponent<Ennemi_Identification>();
                if (ennemi_Identification != null)
                {
                    ennemi_Identification.SetSelectedVisible(true);
                    _selected_ennemi_List.Add(ennemi_Identification);
                }
            }
            List<Vector3> targetPositionList = GetPositionListAround(moveToPosition, new float[] { 2f, 4f, 6f }, new int[] { 5, 10, 15 });
            int targetPositionListIndex = 0;
            foreach (Unit_Identification unit_Identification in _selected_Unit_List)
            {
                unit_Identification.agent.SetDestination(targetPositionList[targetPositionListIndex]);
                targetPositionListIndex = (targetPositionListIndex + 1) % targetPositionList.Count;
            }
            //info deplacement
            /*if (firstSelection && !firstdeplacement)
            {
                firstdeplacement = true;
                gameObject.GetComponent<Camera_Mouvement>().tutoManager.textTuto.text = gameObject.GetComponent<Camera_Mouvement>().tutoManager.tutoPanel[5].textEtapeTuto;
            }*/
        }
    }
    void testTemporaire()
    {
        Collider2D[] collider2DArrayEnnemi = Physics2D.OverlapAreaAll(_startPosition, _endPosition);
        foreach (Ennemi_Identification ennemi_Identification in _selected_ennemi_List)
        {
            ennemi_Identification.SetSelectedVisible(false);
        }
        _selected_ennemi_List.Clear();
        //Select units within selection area
        foreach (Collider2D collider2D in collider2DArrayEnnemi)
        {
            Ennemi_Identification ennemi_Identification = collider2D.GetComponent<Ennemi_Identification>();
            if (ennemi_Identification != null)
            {
                ennemi_Identification.SetSelectedVisible(true);
                _selected_ennemi_List.Add(ennemi_Identification);
            }
        }
    }
    
}
