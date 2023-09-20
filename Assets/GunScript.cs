using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunScript : MonoBehaviour
{
    public GameObject ammoSocket;
    public Transform gunBreach;
    public GameObject depeltedShell;
    public AudioSource gunSound;
    public GameObject gunModel;
    public GameObject crank;
    public AudioSource voiceline;

    bool loadedAmmo;
    bool gunslide;

    public Vector3 disiredRotation;
    public float gunslideAmount;

    Vector3 inital;

    private void Start()
    {
        inital = gunModel.transform.localPosition;
    }

    private void Update()
    {
        if (gunBreach.localRotation.eulerAngles != disiredRotation)
        {
            gunBreach.localEulerAngles = Vector3.Lerp(gunBreach.localRotation.eulerAngles, disiredRotation, 0.05f);
        }
        if (gunslide)
        {
            if (Vector3.Distance(inital, gunModel.transform.localPosition) > gunslideAmount)
                gunslide = false;
            else
                gunModel.transform.Translate(-gunModel.transform.right * gunslideAmount * 5 - gunModel.transform.up/2 * gunslideAmount * 4, Space.Self);
        }else
        {
            if (gunModel.transform.localPosition != inital)
            {
                gunModel.transform.localPosition = Vector3.Lerp(gunModel.transform.localPosition, inital, 0.1f);
            }
        }
        if (!voiceline)
        {
            crank.SetActive(true);
        }
    }

    public void loadAmmo()
    {
        disiredRotation = Vector3.zero;
        loadedAmmo = true;
    }

    public void Fire()
    {
        if (loadedAmmo)
        {
            disiredRotation = new Vector3(0, 120, 0);
            XRSocketInteractor interact = ammoSocket.GetComponent<XRSocketInteractor>();
            Destroy(interact.GetOldestInteractableHovered().transform.gameObject);
            Instantiate(depeltedShell, ammoSocket.transform.position + ammoSocket.transform.right/10, ammoSocket.transform.rotation).GetComponent<Rigidbody>().AddForce(ammoSocket.transform.right * 100);
            gunSound.Play();
            loadedAmmo = false;
            gunslide = true;
            
            voiceline.Play();
            Destroy(voiceline.gameObject, 15.5f);
        }
    }

}
