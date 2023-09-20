using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tea : MonoBehaviour
{
    public AudioSource final;

    private void Update()
    {
        if (!final)
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        teapot teapo;
        if (other.gameObject.TryGetComponent<teapot>(out teapo))
        {
            if (teapo.completedTea)
            {
                final.Play();
                Destroy(final.gameObject, 15);

            }
        }
    }
}
