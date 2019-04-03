using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntajes : MonoBehaviour {
    public int score1 = 100;
    public int final_score = 0;

	void OnGUI()
    {
        GUILayout.Label("Puntos 1 = " + final_score);
    }
}