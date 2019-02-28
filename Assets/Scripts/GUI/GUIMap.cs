using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GUIMap : MonoBehaviour {

	public Properties properties;
	public TownController townController;
	private bool leftPanelState = false;
	private bool rightPanelState = false;
	private bool otherCityPanelStateMain = false;
	private bool otherCityPanelStateMajor = false;
	private bool otherCityPanelStateMarket = false;
    private bool eventMessagePanelState = false;
    public GameObject leftPanel;
	public GameObject rightPanel;
	public GameObject otherCityPanelMain;
	public GameObject otherCityPanelMajor;
	public GameObject otherCityPanelMarket;
    public GameObject eventMessagePanel;
    public Pause pausedControl;
    private const float DistanceRay = 10000f;
    public Player p;
    public Functions f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (properties.getGameState() == GameState.OTHERCITY) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
	}

	public void setLeftPanelState(){
		if (properties.getGameState () == GameState.MOVEMENT) {
			leftPanel.SetActive (leftPanelState = !leftPanelState);
		}
        if (leftPanel.active || rightPanel.active) {
            p.movement();
            p.shipy();
        }
        else {
            p.music();
        }
    }

	public void setRightPanelState(){
		if (properties.getGameState () == GameState.MOVEMENT) {
			rightPanel.SetActive (rightPanelState = !rightPanelState);
		}
        if (leftPanel.active || rightPanel.active) {
            p.movement();
            p.shipy();
        } else {
            p.music();
        }
	}

	public void setOtherCityPanelMainState(){
		otherCityPanelMain.SetActive (otherCityPanelStateMain = !otherCityPanelStateMain);
		properties.setGameState (otherCityPanelStateMain ? GameState.OTHERCITY : GameState.MOVEMENT);
		townController.stop ();
        if (properties.getGameState() == GameState.OTHERCITY) {
            p.otherTown();
            leftPanel.SetActive(false);
            rightPanel.SetActive(false);
            pausedControl.paused = true;
            
        } else {
            if (!(leftPanel.active || rightPanel.active)) {
                p.music();
            }
            pausedControl.paused = false;
            f.v = 0;
        }
	}

	public void setOtherCityPanelMajorState(){
		otherCityPanelMain.SetActive (otherCityPanelStateMain = !otherCityPanelStateMain);
		otherCityPanelMajor.SetActive (otherCityPanelStateMajor = !otherCityPanelStateMajor);
		properties.setGameState (otherCityPanelStateMajor ? GameState.OTHERCITY : GameState.MOVEMENT);
		townController.stop ();
	}

	public void setOtherCityPanelMarketState(){
		otherCityPanelMain.SetActive (otherCityPanelStateMain = !otherCityPanelStateMain);
		otherCityPanelMarket.SetActive (otherCityPanelStateMarket = !otherCityPanelStateMarket);
		properties.setGameState (otherCityPanelStateMarket ? GameState.OTHERCITY : GameState.MOVEMENT);
		townController.stop ();
	}

    public void setEventMessagePanelState() {
        eventMessagePanel.SetActive(eventMessagePanelState = !eventMessagePanelState);
        pausedControl.paused = eventMessagePanelState;
        //properties.setGameState(otherCityPanelStateMain ? GameState.OTHERCITY : GameState.MOVEMENT);
        ///townController.stop();
    }
}
