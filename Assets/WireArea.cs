using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireArea : MonoBehaviour
{
    public int[] lightStatus = new int[16] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    public light[] lights;
    public GameObject Cover;
    public Engine button;

    private void Update()
    {
        updateLights();
        itemCheck();
    }

    public void add(GameObject wire, int x, int y)
    {
        if (wire.tag == "Wire+")
        {
            if (y > 0)
                lightStatus[(y - 1) * 4 + x] += 1;
            if (y < 3)
                lightStatus[(y + 1) * 4 + x] += 1;
            if (x > 0)  
                lightStatus[y * 4 + x - 1] += 1;
            if (x < 3)
                lightStatus[y * 4 + x + 1] += 1;
        }else
        {
            lightStatus[y * 4 + x] += 1;
            if (y > 0)
            {
                if (x > 0)
                    lightStatus[(y - 1) * 4 + x - 1] += 1;
                if (x < 3)
                    lightStatus[(y - 1) * 4 + x + 1] += 1;
            }
            if (y < 3)
            {
                if (x > 0)
                    lightStatus[(y + 1) * 4 + x - 1] += 1;
                if (x < 3)
                    lightStatus[(y + 1) * 4 + x + 1] += 1;
            }
        }
        updateLights();
        itemCheck();
    }

    public void remove(GameObject wire, int x, int y)
    {
        if (wire.tag == "Wire+")
        {
            if (y > 0)
                lightStatus[(y - 1) * 4 + x] -= 1;
            if (y < 3)
                lightStatus[(y + 1) * 4 + x] -= 1;
            if (x > 0)
                lightStatus[y * 4 + x - 1] -= 1;
            if (x < 3)
                lightStatus[y * 4 + x + 1] -= 1;
        }
        else
        {
            lightStatus[y * 4 + x] -= 1;
            if (y > 0)
            {
                if (x > 0)
                    lightStatus[(y - 1) * 4 + x - 1] -= 1;
                if (x < 3)
                    lightStatus[(y - 1) * 4 + x + 1] -= 1;
            }
            if (y < 3)
            {
                if (x > 0)
                    lightStatus[(y + 1) * 4 + x - 1] -= 1;
                if (x < 3)
                    lightStatus[(y + 1) * 4 + x + 1] -= 1;
            }
        }
        updateLights();
        itemCheck();
    }

    void updateLights()
    {
        int index = 0;
        foreach(light li in lights)
        {
            li.ChangeLight(lightStatus[index] > 0);
            index++;
        }
    }

    void itemCheck()
    {
        int onAmount = 0;
        foreach (int boo in lightStatus)
        {
            if (boo > 0)
                onAmount++;
        }
        if (onAmount == 16)
        {
            Cover.SetActive(false);
        }
        if (onAmount > 8)
        {
            button.buttonEnabled = true;
        }
    }
}
