using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variable min et max des zones d'apparition 
    //Zone A
    private Vector2 areaFirstMin;
    private Vector2 areaFirstMax;

    //Zone B
    private Vector2 areaTwoMin;
    private Vector2 areaTwoMax;

    //Zone C
    private Vector2 areaThreeMin;
    private Vector2 areaThreeMax;

    //Nb de zone

    private int nbZones;

    private Vector2[] positionBoundsMin;
    private Vector2[] positionBoundsMax;

    // Objet a instancier
    [SerializeField] private GameObject puceronGenerator;

    // Start is called before the first frame update
    void Start()
    {
        areaFirstMin = new Vector2(-82, 90);
        areaFirstMax = new Vector2(60, 141);
        areaTwoMin = new Vector2(126, -90);
        areaTwoMax = new Vector2(270,24);
        areaThreeMin = new Vector2(30,-212);
        areaThreeMax = new Vector2(183, -198);

        // On stock les position dans un tableau 
        positionBoundsMin = new Vector2[] { areaFirstMin, areaTwoMin, areaThreeMin };
        positionBoundsMax = new Vector2[] { areaFirstMax, areaTwoMax, areaThreeMax };

        // On divise le nombre de position par 2 pour avoir le nombre de zone
        nbZones = positionBoundsMin.Length;

        // Pour les 3 zones
        for (int i = 0; i <= nbZones - 1; i++)
        {
            GenerateNid(positionBoundsMin[i ], positionBoundsMax[i]);
        }

        // On génère le nid avec la position en zone x et et zone x+1

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateNid(Vector2 zoneMin, Vector2 zoneMax)
    {
        Vector3 boundRandom = new Vector3(Random.Range(zoneMin.x, zoneMax.x), Random.Range(zoneMin.y, zoneMax.y), 0);
        Instantiate(puceronGenerator, boundRandom, Quaternion.identity);
    }
}
