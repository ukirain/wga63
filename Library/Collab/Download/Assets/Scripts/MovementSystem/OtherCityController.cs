using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCityController : MonoBehaviour {

	public GUIMap guiMap;
    public Functions f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		guiMap.setOtherCityPanelMainState();
	}
}
