﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
	public uint playerRespawnTime, numberOfPlayers,minionSpawnAmount, monsterSpawnAmount;
	public static uint playersAlive, enemiesAlive;
	public static uint currentLevel = 1;
	[Range(1,10)]
    public static float healthItemDropRateWeight = 1;
    [Range(1, 10)]
    public static float healthItemHealAmountWeight = 1;
    [Range(1, 10)]
    public uint monsterAmountWeight;
    public GameObject MinionPrefab, MonsterPrefab, PlayerPrefab;
    public GameObject[] EnemySpawnPos;
    public GameObject[] PlayerSpawnPos = new GameObject[3];
    public GameObject[] Players = new GameObject[3];
    public static bool SpawnMinions = true;
    static public float healthItemBaseHealAmount;
    [SerializeField]
    private List<int> randomPos = new List<int>();
    public static uint healthItemDropsForLevel = 0;
    public static uint healthItemsAlreadyDropped = 0;
    public uint startLevelHealthItemDrops;


    int nextPos;
    private string element1, element2;

    //UI
    public Text levelText; 

    void Awake() {
        //numbersofplayers set to playersconnected
    }

    void Start() {
        foreach (GameObject enemySpawn in GameObject.FindGameObjectsWithTag("EnemySpawnPos")) {
            Debug.Log("Do i rn 6 times?");
            EnemySpawnPos[nextPos] = enemySpawn;
            nextPos++;
        }
        startLevel(currentLevel);
    }

    void FixedUpdate() {
        checkGameState(playersAlive, enemiesAlive);
        if (Input.GetKeyDown("a")) {
            endLevel();
        }
    }

    private void UIElements() {
        levelText.text = "Level: " + currentLevel;
    }

    private void startLevel(uint currentLevel){
        healthItemDropsForLevel = startLevelHealthItemDrops - currentLevel;
        healthItemsAlreadyDropped = 0;
		spawnEnemies(minionSpawnAmount, monsterSpawnAmount, currentLevel);
		spawnPlayers();
        UIElements();
	}

    private void generateRandomElement() {
        int rNumb = Random.Range(0, 2);
        List<string> randomElements = new List<string> { "fire", "water", "earth" };
        randomElements.RemoveAt(rNumb);
        element1 = randomElements[0];
        element2 = randomElements[1];
    }

	private void spawnEnemies(uint minionSpawnAmount, uint monsterSpawnAmount, uint currentLevel){
        int nextSpawnPoint = 0;
		minionSpawnAmount *= monsterAmountWeight * currentLevel;
		monsterSpawnAmount *= monsterAmountWeight * currentLevel;
        for (int i = 0; i < EnemySpawnPos.Length; i++) {
            randomPos.Add(i);
        }
        for (int i = 0; i < randomPos.Count; i++) {
            int temp = randomPos[i];
            int randomIndex = Random.Range(i, randomPos.Count);
            randomPos[i] = randomPos[randomIndex];
            randomPos[randomIndex] = temp;
        }

        for (int i = 0; i < minionSpawnAmount; i++) {
            nextSpawnPoint++;
            GameObject Temporary_Enemy_Handler;
            Temporary_Enemy_Handler = Instantiate(MinionPrefab, EnemySpawnPos[randomPos[i]].transform.position, EnemySpawnPos[randomPos[i]].transform.rotation) as GameObject;
            generateRandomElement();
            //randomPos.RemoveAt(randomPos[i]);
            if (Random.Range(0,1) == 0) {
                Temporary_Enemy_Handler.GetComponent<Minion>().element = element1;
            } else
                Temporary_Enemy_Handler.GetComponent<Minion>().element = element2;
            enemiesAlive++;
        }

        for (int i = 0; i < monsterSpawnAmount; i++) {
            
            GameObject Temporary_Enemy_Handler;
            Temporary_Enemy_Handler = Instantiate(MonsterPrefab, EnemySpawnPos[randomPos[i + nextSpawnPoint]].transform.position, EnemySpawnPos[randomPos[i + nextSpawnPoint]].transform.rotation) as GameObject;
            //randomPos.RemoveAt(randomPos[i]);
            generateRandomElement();
            Temporary_Enemy_Handler.GetComponent<Monster>().element1 = element1;
            Temporary_Enemy_Handler.GetComponent<Monster>().element2 = element2;
            enemiesAlive++;
        }
        
    }

    private void spawnPlayers(){
        for (int i = 0; i < numberOfPlayers; i++) {
            GameObject Temporary_Player_Handler;
            Temporary_Player_Handler = Instantiate(PlayerPrefab, PlayerSpawnPos[i].transform.position, PlayerSpawnPos[i].transform.rotation) as GameObject;
            Players[i] = Temporary_Player_Handler;
            playersAlive++;

        }
	}	

	private void checkGameState(uint playersAlive, uint enemiesAlive){
        if (playersAlive == 0){
			endLevel();
			startLevel(currentLevel);
            Debug.Log("All players died!");
        } else if(enemiesAlive == 0){
            endLevel();
            startLevel(currentLevel++);
            Debug.Log("All enemies died!");
        }
	}
	
	private void endLevel(){
        if (enemiesAlive != 0) {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
                Destroy(enemy);
                enemiesAlive--;
            }
        }
        
        if (playersAlive != 0) {
            foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
                Destroy(player);
                playersAlive--;
            }
        }
    }
}
