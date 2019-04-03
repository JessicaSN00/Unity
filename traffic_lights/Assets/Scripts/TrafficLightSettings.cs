using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightSettings : MonoBehaviour {

    public float _time = 10f;
    public float timeS = 5f;
    public float green_time = 10f;
    public TrafficLights[] semaforos = new TrafficLights[4];
    public GameObject trigger;
    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;

    private int actualSignal = 0;
    private int stepper = 0;
    private float timeControl = 0;
    private bool alert = false;
    private bool greenR = true;
    public bool red = false;

    void Update()
    {
        //Initialize with Green Signal
        RestartG();
        //Sequence1 Green to Yellow, Sequence2 stay in Red
        if (timeControl >= green_time && !alert && this.stepper == 0)
        {
            red = false;
            timeControl = 5;
            semaforos[actualSignal].caution();
            semaforos[actualSignal + 3].caution();
            alert = true;
            this.stepper += 1;
        }
        
        //Sequence1 Yellow to Red, Sequence2 Red to GreenBlink
        else if (timeControl >= _time && alert && this.stepper == 1)
        {
            timeControl = 0;
            red = true;
            
            //True on red
            trigger.SetActive(true);
            trigger1.SetActive(true);


            //False on red (opposite)
            trigger2.SetActive(false);
            trigger3.SetActive(false);

            semaforos[actualSignal].stop();
            semaforos[actualSignal + 3].stop();

            StartCoroutine(Blink());

            if (actualSignal == 3)
            {
                //Restart all sequences with Green Signal
                actualSignal = 0;
                alert = false;
                greenR = true;
            }
            //Use _time with double time for Red and GreenR Signals
            else if (timeControl >= timeS && greenR == false)
            {
                timeControl = 0;
                RestartG();
                greenR = true;
            }
            StopCoroutine(Blink());
            this.stepper += 1;
        }
        else if (timeControl >= green_time && this.stepper == 2)
        {
            timeControl = 5;
            red = false;
            semaforos[actualSignal + 1].caution();
            semaforos[actualSignal + 2].caution();
            this.stepper += 1;
        }
        else if (timeControl >= green_time && greenR == false && this.stepper == 3)
        {
            red = false;
            timeControl = 0;
            RestartG();
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
    private void RestartG() {
        if (greenR == true) {
            //False on green
            trigger.SetActive(false);
            trigger1.SetActive(false);

            //True on green (opposite)
            trigger2.SetActive(true);
            trigger3.SetActive(true);

            StartCoroutine(BlinkN());

            red = true;

            semaforos[actualSignal + 1].stop();
            semaforos[actualSignal + 2].stop();

            greenR = false;
            alert = false;
            timeControl = 0;
        }
    }

    //Blink Sequence for Green Signal
    IEnumerator Blink()
    {
        semaforos[actualSignal + 1].proceed();
        semaforos[actualSignal + 2].proceed();
        yield return new WaitForSeconds(6.5f);
        semaforos[actualSignal + 1].off();
        semaforos[actualSignal + 2].off();
        yield return new WaitForSeconds(0.5f);

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
        
        semaforos[actualSignal].proceed();
        semaforos[actualSignal + 3].proceed();
        yield return new WaitForSeconds(6.5f);
        semaforos[actualSignal].off();
        semaforos[actualSignal + 3].off();
        yield return new WaitForSeconds(0.5f);

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
