using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	public uint initialMinionAmount, playerRespawnTime, numberOfPlayers, initialMonsterAmount, minionSpawnAmount, monsterSpawnAmount;
	private uint playersAlive, enemiesAlive;
	public uint currentLevel = 1;
	public Vector3 enemySpawnPosition1, numberOfPlayer, enemySpawnPosition2, enemySpawnPosition3;

    public Vector3[] playerPositions;

    [Range(1,10)]
	public float healthItemDropRateWeight;
	[Range(1,10)]
	public uint monsterAmountWeight;
	[Range(1,10)]
	public float healthItemHealAmountWeight;
	public uint currentLevel; 

	private void startGame(){
		
	}

	private void startLevel(uint currentLevel){
		spawnEnemies(minionSpawnAmount, monsterSpawnAmount, currentLevel);
		healthItemDropRate(currentLevel);
		healthItemHealAmount(currentLevel);
	}

	private void spawnEnemies(uint minionSpawnAmount, uint monsterSpawnAmount, uint currentLevel){
		minionSpawnAmount *= monsterAmountWeight * level;
		monsterSpawnAmount *= monsterAmountWeight * level;
		// choose where to spawn the enemies
	}

	private void spawnPlayers(uint numberOfPlayers){
		// choose where to spawn players
	}


	public float healthItemDropRate(uint currentLevel){
		float dropRate = 100.0f / (healthItemDropRateWeight * level);
		return dropRate;
		// make this work when enemies die
	}

		float healthItemHealAmount(uint currentLevel){
			float healAmount = 100.0f / (healthItemHealAmountWeight * level);
			return healAmount;
			// make this work with enemies
	}
	

	private void checkGameState(uint playersAlive, uint enemiesAlive){

		if(playersAlive == 0){
			endLevel();
			startLevel(currentLevel);
		}

		if(enemiesAlive == 0){
			endLevel();
			startLevel(currentLevel++);
		}
	}
	
	private void endLevel(){
		// destroy enemies
		// destroy players
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
