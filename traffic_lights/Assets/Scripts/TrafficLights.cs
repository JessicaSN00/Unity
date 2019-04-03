using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLights : MonoBehaviour
{
    public Light PLlight;
    public GameObject greenSignal;
    public GameObject yellowSignal;
    public GameObject redSignal;

    void Start()
    {
        stop();
    }

    //Green Light
    public void proceed()
    {
        greenSignal.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        yellowSignal.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        redSignal.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        PLlight.color = Color.green;
    }

    //Yellow Light
    public void caution()
    {
        greenSignal.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        yellowSignal.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        redSignal.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        PLlight.color = Color.yellow;
    }

    //Red Light
    public void stop()
    {
        greenSignal.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        yellowSignal.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        redSignal.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        PLlight.color = Color.red;
    }

    public void off()
    {
        greenSignal.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        yellowSignal.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        redSignal.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        PLlight.color = Color.clear;
    }
}
