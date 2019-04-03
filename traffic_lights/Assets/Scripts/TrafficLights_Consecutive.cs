using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public float _time = 6f;
    public float timeS = 3f;
    public TrafficLights[] semaforos = new TrafficLights[4];

    private int actualSignal = 0;
    private float timeControl = 0;
    private bool alert = false;
    private bool greenR = true;

    void Update()
    {
        //Initialize with Green Signal
        RestartG();
        //Before Green proceed to Yellow Signal
        if (timeControl >= timeS && alert == false)
        {
            timeControl = 0;
            semaforos[actualSignal].caution();
            alert = true;
            //Before Yellow proceed to Red Signal
        }
        else if (timeControl >= timeS && alert == true)
        {
            semaforos[actualSignal].stop();

            if (actualSignal == 3)
            {
                //Restart the sequence with Green Signal
                actualSignal = 0;
                alert = false;
                greenR = true;
            }
            //Use _time with double time for Red and GreenR Signals
            else if (timeControl >= _time && greenR == false)
            {
                timeControl = 0;
                RestartG();
                NextSignal();
                greenR = true;
            }
        }
        else
        {
            RestartG();
        }
        timeControl += (1 * Time.deltaTime);
    }

    //Restart Green Signal and proceed to Yellow
    private void RestartG()
    {
        if (greenR == true)
        {
            timeControl = 0;
            semaforos[actualSignal].proceed();
            greenR = false;
            alert = false;
        }
    }

    //Signal Sequence
    private void NextSignal()
    {
        if (actualSignal < 4)
        {
            actualSignal++;
        }
        else
        {
            actualSignal = 0;
        }
    }
}
