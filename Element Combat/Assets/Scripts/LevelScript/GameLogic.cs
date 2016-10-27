using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	public int initialMinionAmount, playerRespawnTime, numberOfPlayers, initialMonsterAmount, minionSpawnAmount, monsterSpawnAmount, playersAlive, enemiesAlive;
	public int currentLevel = 1;
	public Vector3 enemySpawnPosition1, numberOfPlayer, enemySpawnPosition2, enemySpawnPosition3;

    public Vector3[] playerPositions; 

	private void startGame(){

	}

	private void startLevel(int currentLevel){
	
	}

	private void spawnEnemies(int minionSpawnAmount, int monsterSpawnAmount){
	
	}

	private void spawnPlayers(int numberOfPlayers){
	
	}

	private void endLevel(){
		
	}

	private void checkGameState(int playersAlive, int enemiesAlive){

		if(playersAlive == 0){
			endLevel();
			startLevel(currentLevel);
		}

		if(enemiesAlive == 0){
			endLevel();
			startLevel(currentLevel++);
		}
	}

	// Use this for initialization
	void Awake(){
		startLevel (1);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		checkGameState (playersAlive, enemiesAlive);
	}
}
