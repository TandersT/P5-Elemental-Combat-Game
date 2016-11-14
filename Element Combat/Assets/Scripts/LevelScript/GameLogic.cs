using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	public uint playerRespawnTime, numberOfPlayers,minionSpawnAmount, monsterSpawnAmount;
	public static uint playersAlive, enemiesAlive;
	public static uint currentLevel = 1;
    public int numberOfPlayer;
	[Range(1,10)]
    public static float healthItemDropRateWeight = 1;
    [Range(1, 10)]
    public static float healthItemHealAmountWeight = 5;
    [Range(1, 10)]
    public uint monsterAmountWeight;
    public GameObject MinionPrefab, MonsterPrefab, PlayerPrefab;
    public GameObject[] EnemySpawnPos = new GameObject[3];
    public GameObject[] PlayerSpawnPos = new GameObject[3];
    public static bool SpawnMinions = true;

    void Awake() {
        startLevel(currentLevel);
    }


    void Start() {

    }

    void Update() {
        checkGameState(playersAlive, enemiesAlive);
        if (Input.GetKeyDown("a")) {
            endLevel();
        }
    }

    private void startLevel(uint currentLevel){
		spawnEnemies(minionSpawnAmount, monsterSpawnAmount, currentLevel);
		spawnPlayers(numberOfPlayers);
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
        for (int i = 0; i < minionSpawnAmount; i++) {
            GameObject Temporary_Enemy_Handler;
            int randomSpawnPos = Random.Range(0, EnemySpawnPos.Length);
            Temporary_Enemy_Handler = Instantiate(MinionPrefab, EnemySpawnPos[randomSpawnPos].transform.position, EnemySpawnPos[randomSpawnPos].transform.rotation) as GameObject;
            Temporary_Enemy_Handler.GetComponent<Minion>().element = generateRandomElement();
            enemiesAlive++;
        }
        for (int i = 0; i < monsterSpawnAmount; i++) {
            GameObject Temporary_Enemy_Handler;
            int randomSpawnPos = Random.Range(0, EnemySpawnPos.Length);
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
