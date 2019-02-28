using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour {

    public Button quitButton;

	// Use this for initialization
	void Start () {
        quitButton.onClick.AddListener(quit);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void quit() {
        Application.Quit();
    }
}
