using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	public GameObject objeto;
    public GameObject punto;

	// Use this for initialization

    void OnTriggerEnter(Collider other)
    {
        Vector3 startPosition = punto.transform.position;
        Debug.Log(startPosition);
        if (other.gameObject.tag == "objeto")
        {
            objeto.transform.position = startPosition;
            Debug.Log("Nueva posicion"+objeto.transform.position);
        }
    }
}
