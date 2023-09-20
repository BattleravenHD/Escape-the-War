using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPipe : MonoBehaviour
{
    public GameObject steam;
    public GameObject water;
    public MeshRenderer redpipe;
    public GaugeScript[] gauges;
    public Material basemat;
    public Material glowmat;
    public Engine engine;
    public AudioSource killall;
    float averageflow;

    private void Update()
    {
        foreach(GaugeScript gauge in gauges)
        {
            if (gauge.currentPressure == 0)
            {
                averageflow = 0;
                break;
            }
            else
                averageflow += gauge.currentPressure;
        }
        averageflow /= gauges.Length;
        if (engine.engineOn)
        {
            switch (averageflow)
            {
                case 0:
                    steam.SetActive(false);
                    water.SetActive(false);
                    redpipe.material = basemat;
                    break;
                case < 100:
                    steam.SetActive(false);
                    water.SetActive(true);
                    redpipe.material = basemat;
                    break;
                case < 125:
                    steam.SetActive(true);
                    water.SetActive(false);
                    redpipe.material = basemat;
                    break;
                case < 150:
                    steam.SetActive(true);
                    water.SetActive(false);
                    redpipe.material = glowmat;
                    break;
                default:
                    steam.SetActive(true);
                    water.SetActive(false);
                    redpipe.material = glowmat;
                    break;
            }
        }else
        {
            steam.SetActive(false);
            water.SetActive(false);
            redpipe.material = basemat;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Teapot" && averageflow > 125)
        {
            teapot pot = other.GetComponent<teapot>();
            if (pot.teaWater)
                pot.completedTea = true;
        }
    }
}
