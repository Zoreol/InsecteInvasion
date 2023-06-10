using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrintManager : MonoBehaviour
{
    [SerializeField] private Material mat_invalid;
    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private List<Building_Datas> datas = new List<Building_Datas>();

    private int _layerMaskTerrain = 1 << 6;
    private GameObject blueprintGO;
    private BluePrintCtrl bluePrint;
    private int dataIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blueprintGO)
        {
            //SetMaterial();
            //CursorControlls();
        }
    }
}
