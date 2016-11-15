using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
	public uint playerRespawnTime, numberOfPlayers,minionSpawnAmount, monsterSpawnAmount;
	public static uint playersAlive, enemiesAlive;
	public static uint currentLevel = 1;
    public int numberOfPlayer;
	[Range(1,10)]
    public static float healthItemDropRateWeight = 1;
    [Range(1, 10)]
    public static float healthItemHealAmountWeight = 1;
    [Range(1, 10)]
    public uint monsterAmountWeight;
    public GameObject MinionPrefab, MonsterPrefab, PlayerPrefab;
    public GameObject[] EnemySpawnPos = new GameObject[3];
    public GameObject[] PlayerSpawnPos = new GameObject[3];
    public static bool SpawnMinions = true;
    static public float healthItemBaseDropRate, healthItemBaseHealAmount;
    [SerializeField]
    private float HIDropRate, HIHealAmount;
    private List<int> randomPos = new List<int>();

    //UI
    public Text levelText; 

    void Awake() {
        startLevel(currentLevel);
        healthItemBaseDropRate = HIDropRate;
        healthItemBaseHealAmount = HIHealAmount;
    }

    void Start() {

    }

    void Update() {
        checkGameState(playersAlive, enemiesAlive);
        if (Input.GetKeyDown("a")) {
            endLevel();
        }
    }

    private void UIElements() {
        levelText.text = "Level: " + currentLevel;
    }

    private void startLevel(uint currentLevel){
		spawnEnemies(minionSpawnAmount, monsterSpawnAmount, currentLevel);
		spawnPlayers(numberOfPlayers);
        UIElements();
	}

    private string generateRandomElement() {
        int rNumb = Random.Range(0, 2);
        string[] rElement = new string[3];
        string chosenElement;
        rElement[0] = "fire"; rElement[1] = "water"; rElement[2] = "earth";
        chosenElement = rElement[rNumb];
        return chosenElement;
    }

	private void spawnEnemies(uint minionSpawnAmount, uint monsterSpawnAmount, uint currentLevel){
		minionSpawnAmount *= monsterAmountWeight * currentLevel;
		monsterSpawnAmount *= monsterAmountWeight * currentLevel;
        for (int i = 0; i < EnemySpawnPos.Length; i++) {
            randomPos.Add(i);
        }
        int randomSpawnPos = Random.Range(0, randomPos.Count);
        randomPos.RemoveAt(randomSpawnPos);
        for (int i = 0; i < minionSpawnAmount; i++) {
            GameObject Temporary_Enemy_Handler;
            Temporary_Enemy_Handler = Instantiate(MinionPrefab, EnemySpawnPos[randomPos[i]].transform.position, EnemySpawnPos[randomPos[i]].transform.rotation) as GameObject;
            Temporary_Enemy_Handler.GetComponent<Minion>().element = generateRandomElement();
            enemiesAlive++;
        }
        for (int i = 0; i < monsterSpawnAmount; i++) {
            GameObject Temporary_Enemy_Handler;
            Temporary_Enemy_Handler = Instantiate(MonsterPrefab, EnemySpawnPos[randomSpawnPos].transform.position, EnemySpawnPos[randomSpawnPos].transform.rotation) as GameObject;
            Temporary_Enemy_Handler.GetComponent<Monster>().element = generateRandomElement();
            enemiesAlive++;
        }
        
    }

    private void spawnPlayers(uint numberOfPlayers){
        for (int i = 0; i < numberOfPlayers; i++) {
            GameObject Temporary_Player_Handler;
            Temporary_Player_Handler = Instantiate(PlayerPrefab, PlayerSpawnPos[i].transform.position, PlayerSpawnPos[i].transform.rotation) as GameObject;

            //Instantiate
            playersAlive++;
        }
	}	

	private void checkGameState(uint playersAlive, uint enemiesAlive){
        if (playersAlive == 0){
			endLevel();
			startLevel(currentLevel);
        }

		if(enemiesAlive == 0){
            endLevel();
            startLevel(currentLevel++);
        }
	}
	
	private void endLevel(){
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            Destroy(enemy);
        }
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            Destroy(player);
        }
    }
}
