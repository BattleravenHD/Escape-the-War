using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Teapot")
        {
            other.GetComponent<teapot>().isFullofwater = true;
        }
    }
}
