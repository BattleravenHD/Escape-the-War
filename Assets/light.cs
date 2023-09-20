using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public bool isOn = false;
    [SerializeField] GameObject lightSource;
    [SerializeField] GameObject Glow;
    [SerializeField] GameObject Glass;

    Material glow;
    Material glass;

    private void Start()
    {
        glow = Glow.GetComponent<MeshRenderer>().material;
        glass = Glass.GetComponent<MeshRenderer>().material;
        ChangeLight(false);
    }

    public void ChangeLight(bool status)
    {
        isOn = status;
        if (!isOn)
        {
            lightSource.SetActive(false);
            glow.color = new Color(1, 1, 1);
            glass.color = new Color(1, 1, 1, 0.3568628f);
            glow.SetColor("_EmissionColor", Color.white);
        }
        else
        {
            lightSource.SetActive(true);
            glow.color = new Color(0.1265824f, 1, 0);
            glass.color = new Color(0.3593603f, 1, 0, 0.3568628f);
            glow.SetColor("_EmissionColor", Color.green);
        }
    }
}
