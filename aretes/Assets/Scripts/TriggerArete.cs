using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArete : MonoBehaviour {

    public AudioSource party;
    public ParticleSystem system;
    public GameObject orejaR;
    public GameObject areton;

    void OnTriggerEnter(Collider other) {
        orejaR = GameObject.FindWithTag("orejaR");
        areton = GameObject.FindWithTag("areton");

        if (other.tag == "areton")
        {
            Debug.Log("Ahora es tiempo del confeti");
            Vector3 pos = orejaR.transform.position;

            areton.transform.position = pos;

            Vector3 ar = areton.transform.position;

            system.Play();
            party.Play();
            Debug.Log(pos);
            Debug.Log(ar);
        }
    }
}
