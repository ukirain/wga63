using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public bool paused = false;
    public GameObject camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!paused) {
                Time.timeScale = 0;
                paused = true;
                //camera.GetComponent(SepiaToneEffect).enabled = true;
            }
            else {
                Time.timeScale = 1;
                paused = false;
                //camera.GetComponent(SepiaToneEffect).enabled = false;
            }
        } else {
            if (paused) {
                Time.timeScale = 0;
                //paused = true;
                //camera.GetComponent(SepiaToneEffect).enabled = true;
            }
            else {
                Time.timeScale = 1;
                //paused = false;
                //camera.GetComponent(SepiaToneEffect).enabled = false;
            }
        }
	}
}
