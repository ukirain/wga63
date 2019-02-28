using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherTownSys : MonoBehaviour {

    public int peasants;
    public int water;
    public int stocks;
    public Button marketButton;
    public Text hirePeople;
    private IEnumerator coroutine;
    private int seconds = 2;

    // Use this for initialization
    void Start () {
        peasants = 20;
        water = 20;
        stocks = 10;

        coroutine = WaitAndPrint(seconds);
        StartCoroutine(coroutine);
    }
	
	// Update is called once per frame
	void Update () {
        hirePeople.text = peasants.ToString();
	}

    private IEnumerator WaitAndPrint(float waitTime) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            print("This is our house! " + Time.time);
        }
    }

}
