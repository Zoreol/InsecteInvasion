using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    [SerializeField] private Ville_Araigne _vA;
    [SerializeField] private Ville_Gendarme_Sauvage _vGS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_vA.Ville_Spider_Captured && _vGS.Captured)
        {
            SceneManager.LoadScene("Fin");
        }
    }
}
