using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	/*void OnGUI () {
    if (GUI.Button(new Rect(10, 70, 50, 30), "Entrar")) {
        Application.LoadLevel("SampleScene");
		Debug.Log("Button with text");
    	}
	}
	    void OnGUI () {
		// Make a background box
			GUI.Box(new Rect(10,10,100,90), "Loader Menu");

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
				Application.LoadLevel(1);
			}

			// Make the second button.
			if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
				Application.LoadLevel(2);
			}
		}*/
		void OnGUI()
			{
				GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
				Debug.Log("GUI halleluja");
			}
	}

