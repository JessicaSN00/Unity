using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightR : MonoBehaviour {
    public Light greenSignal;
    public Light yellowSignal;
    public Light redSignal;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Light>().enabled = false;
    }
}
