using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoton : MonoBehaviour {

    public GameObject orejaL;
    public GameObject boton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        orejaL = GameObject.FindWithTag("orejaL");
        boton = GameObject.FindWithTag("boton");

        if (other.tag == "boton")
        {
            Vector3 posss = orejaL.transform.position;

            boton.transform.position = posss;

            Vector3 ar2 = boton.transform.position;

            Debug.Log(posss);
            Debug.Log(ar2);
        }
    }
}
