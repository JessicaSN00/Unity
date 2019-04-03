using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestActividad : MonoBehaviour {
    public int score1 = 100;
    public int final_score = 0;
    void OnTriggerEnter(Collider other)
    {
        Renderer render = GetComponent<Renderer>();
        render.material.color = Color.black;

        if (other.tag == "Coche")
        {
            score1 -= 10;
            Debug.Log("Score is now " + score1);
        }
        final_score = score1;

    }
    
	void OnGUI()
    {
        GUILayout.Label("Puntos 1 = " + final_score);
    }

}
