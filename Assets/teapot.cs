using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teapot : MonoBehaviour
{
    public bool isFullofwater;
    public bool teaBag;

    public bool teaWater;
    public bool completedTea;

    public GameObject water;
    public GameObject lid;
    public GameObject steam;

    private void Update()
    {
        if (isFullofwater && teaBag)
            teaWater = true;
        if (teaWater)
            lid.SetActive(true);
        if (isFullofwater)
            water.SetActive(true);
        if (completedTea)
            steam.SetActive(true);
    }

    public void addTeaBag(Collider collider)
    {
        teaBag = true;
        Destroy(collider);
    }
}
