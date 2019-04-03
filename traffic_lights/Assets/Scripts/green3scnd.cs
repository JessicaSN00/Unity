using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green3scnd : MonoBehaviour {


    public float _time = 6f;
    public float timeS = 3f;
    public float timeBlink = 3f;
    public TrafficLights[] semaforos = new TrafficLights[4];

    private int actualSignal = 0;
    private float timeControl = 0;
    private bool alert = false;
    private bool greenR = true;
    private int stepper = 0;

    void Update()
    {
        //Initialize with Green Signal
        RestartG();
        //Before Green, proceed to Yellow Signal
        if (timeControl >= timeS && !alert && this.stepper == 0)
        {
            semaforos[actualSignal].caution();
    semaforos[actualSignal + 3].caution();

    alert = true;
            this.stepper += 1;
            //Before Yellow, proceed to Red Signal
        }
        else if (timeControl >= _time && alert && this.stepper == 1)
        {
    timeControl = 0;
    semaforos[actualSignal].stop();
    semaforos[actualSignal + 3].stop();

    StartCoroutine(Blink());

    if (actualSignal == 3)
    {
        //Restart the sequence with Green Signal
        actualSignal = 0;
        alert = false;
        greenR = true;
    }
    //Use _time with double time for Red and GreenR Signals
    else if (timeControl >= timeS && greenR == false)
    {
        timeControl = 0;
        RestartG();
        //NextSignal();
        greenR = true;
    }
    StopCoroutine(Blink());
    this.stepper += 1;
}
        else if (timeControl >= timeS && this.stepper == 2)
        {
    //timeControl = 0;
    semaforos[actualSignal + 1].caution();
    semaforos[actualSignal + 2].caution();
    this.stepper += 1;
}
        else if (timeControl >= _time && greenR == false && this.stepper == 3)
        {
    timeControl = 0;
    RestartG();
    //NextSignal();
    greenR = true;
    this.stepper = 0;
}
        else
        {
    RestartG();
}
timeControl += (1 * Time.deltaTime);
}

//Restart actual signal and proceed to the next one
private void RestartG()
{
    if (greenR == true)
    {
        //timeControl = 0;
        StartCoroutine(BlinkN());

        semaforos[actualSignal + 1].stop();
        semaforos[actualSignal + 2].stop();

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

//Blink Sequence for Green Signal
IEnumerator Blink()
{
    /*
    semaforos[actualSignal + 1].proceed();
    semaforos[actualSignal + 2].proceed();
    yield return new WaitForSeconds(2.5f);
    semaforos[actualSignal + 1].off();
    semaforos[actualSignal + 2].off();
    yield return new WaitForSeconds(0.5f);*/

    for (int i = 0; i < 3; i++)
    {
        semaforos[actualSignal + 1].proceed();
        semaforos[actualSignal + 2].proceed();
        yield return new WaitForSeconds(0.5f);
        semaforos[actualSignal + 1].off();
        semaforos[actualSignal + 2].off();
        yield return new WaitForSeconds(0.5f);
    }
}

IEnumerator BlinkN()
{
    /*
    semaforos[actualSignal].proceed();
    semaforos[actualSignal + 3].proceed();
    yield return new WaitForSeconds(2.5f);
    semaforos[actualSignal].off();
    semaforos[actualSignal + 3].off();
    yield return new WaitForSeconds(0.5f);*/

    for (int i = 0; i < 3; i++)
    {
        semaforos[actualSignal].proceed();
        semaforos[actualSignal + 3].proceed();
        yield return new WaitForSeconds(0.5f);
        semaforos[actualSignal].off();
        semaforos[actualSignal + 3].off();
        yield return new WaitForSeconds(0.5f);
    }
}
}
