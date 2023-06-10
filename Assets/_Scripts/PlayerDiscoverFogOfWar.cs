using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiscoverFogOfWar : MonoBehaviour
{
    public FogOfWar fogOfWar;
    public Transform secondaryFogOfWar;
    public float sightDistance;
    public float checkInterval;
    public bool building;

    void Start()
    {
        if (!building)
        {
            fogOfWar = FindObjectOfType<FogOfWar>();
            StartCoroutine(CheckFogOfWar(checkInterval));
        }
        else
        {
            DiscoverBuilding();
        }
        secondaryFogOfWar.localScale = new Vector2(sightDistance, sightDistance) * 10f;
    }
    void DiscoverBuilding()
    {
        fogOfWar.MakeHole(transform.position, sightDistance);
    }
    private IEnumerator CheckFogOfWar(float checkInterval)
    {
        while (true)
        {
            fogOfWar.MakeHole(transform.position, sightDistance);
            yield return new WaitForSeconds(checkInterval);
        }
    }
}
