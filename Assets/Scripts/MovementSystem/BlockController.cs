using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    public RandomEvents re;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D other) {
        re.ev.StartEvent(13);
        System.Threading.Thread.Sleep(1000);
        Debug.Log("GAME OVER");
        Application.Quit();
    }
}
