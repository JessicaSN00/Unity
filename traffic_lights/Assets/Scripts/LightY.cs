using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightY : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Light>().enabled = false;
    }
}
