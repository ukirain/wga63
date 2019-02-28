using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour {

	public GameState gameState;


	public GameState getGameState(){
		return gameState;
	}

	public void setGameState(GameState gameState){
		this.gameState = gameState;
	}
}
