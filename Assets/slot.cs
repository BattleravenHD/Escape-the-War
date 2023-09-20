using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class slot : MonoBehaviour
{
    public int X;
    public int Y;

    public WireArea area;
    private GameObject lastItem;

    public void add()
    {
        area.add(GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject, X, Y);
        lastItem = GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject;
    }
    public void remove()
    {
        area.remove(lastItem, X, Y);
        lastItem = null;
    }
}
