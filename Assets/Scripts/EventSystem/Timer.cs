using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    float seconds = 2.0f;
    private IEnumerator coroutine;

    // Use this for initialization
    void Start () {
        coroutine = WaitAndPrint(seconds);
        StartCoroutine(coroutine);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private IEnumerator WaitAndPrint(float waitTime) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            print("Boop! " + Time.time);
        }
    }

    void setCoroutine(IEnumerator pNewCoroutine) {
        coroutine = pNewCoroutine;
    }
}
