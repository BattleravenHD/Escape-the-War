using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public bool engineOn;
    public bool buttonEnabled;
    public DialInteractable crank;
    public GameObject button;
    public GameObject[] toactivate;
    public AudioSource teaAudio;

    int crankAmount = 0;
    float crankPrevious;

    private void Start()
    {
        crankPrevious = 0;
    }

    private void Update()
    {
        if (crank.CurrentAngle != crankPrevious)
        {
            crankPrevious = crank.CurrentAngle;
            crankAmount += 10;
        }else
        {
            crankAmount = Mathf.Clamp(crankAmount - 1, 0, 10000);
        }
        if (buttonEnabled)
        {
            button.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
        }else
            button.GetComponent<MeshRenderer>().material.color = new Color(.25f, .25f, .25f);
    }
    public void startEngine()
    {
        
        if (crankAmount > 100 && buttonEnabled)
        {
            engineOn = true;
            foreach (GameObject activeate in toactivate)
            {
                activeate.SetActive(true);
            }
            teaAudio.Play();
            Destroy(teaAudio.gameObject, 40);
        }
    }
}
