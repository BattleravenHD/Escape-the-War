using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeScript : MonoBehaviour
{
    public int currentPressure;
    public int scaler = 1;
    public Transform gauge;
    public GaugeScript[] flowons;
    public DialInteractable currentDial;

    private void Update()
    {
        change();
    }

    public void change()
    {
        currentPressure = Mathf.Clamp(Mathf.RoundToInt(currentDial.CurrentAngle/ currentDial.RotationAngleMaximum * 100 * scaler), 0, 100);
        foreach (GaugeScript flow in flowons)
        {
            flow.scaler = currentPressure / 10;
            flow.currentPressure = Mathf.Clamp(Mathf.RoundToInt(flow.currentDial.CurrentAngle/flow.currentDial.RotationAngleMaximum * 100 * flow.scaler), 0, 100);
            flow.updateDial();
        }
        updateDial();
    }

    public void updateDial()
    {
        gauge.localRotation = Quaternion.Euler(Mathf.Clamp(45-currentDial.RotationAngleMaximum/100 * currentPressure, -180, 0) ,90,-90) ;
    }
}
