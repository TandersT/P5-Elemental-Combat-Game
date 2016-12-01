using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
    public uint playerRespawnTime, numberOfPlayers, minionSpawnAmount, monsterSpawnAmount;
    public static uint playersAlive, enemiesAlive;
    public static uint currentLevel = 1;
    [Range(1, 10)]
    public static float healthItemDropRateWeight = 1;
    [Range(1, 10)]
    public static float healthItemHealAmountWeight = 1;
    [Range(1, 10)]
    public uint monsterAmountWeight;
    public GameObject FireMinionPrefab, WaterMinionPrefab, EarthMinionPrefab, MudMonsterPrefab, GlassMonsterPrefab, SteamMonsterPrefab, FirePlayerPrefab, WaterPlayerPrefab, EarthPlayerPrefab;
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
    public uint[] minionsSpawnOnButton = new uint[4] { 5, 10, 15, 20 };
    bool playersSpawned;
    float timePassed;
    float completionTime;
    bool enemyHasSpawned;
    public float repspawnTime;


    private string element, element1, element2;
    private int nextPos;
    //UI
    public Text levelText;

    void Awake() {
        startLevel(currentLevel);
    }

    void Start() {
        Random.InitState(42);
        foreach (GameObject enemySpawn in GameObject.FindGameObjectsWithTag("EnemySpawnPos")) {
            EnemySpawnPos[nextPos] = enemySpawn;
            nextPos++;
        }
    }

    void OnGUI() {
        if (enemiesAlive == 0) {
            if (GUI.Button(new Rect(10, 10, 80, 50), "1. wave"))
                spawnEnemies(minionsSpawnOnButton[0], 0, 1);
            if (GUI.Button(new Rect(10, 60, 80, 50), "2. wave"))
                spawnEnemies(minionsSpawnOnButton[1], 0, 1);
            if (GUI.Button(new Rect(10, 110, 80, 50), "3. wave"))
                spawnEnemies(minionsSpawnOnButton[2], 0, 1);
            if (GUI.Button(new Rect(10, 170, 80, 50), "4. wave"))
                spawnEnemies(minionsSpawnOnButton[3], 0, 1);
        }
    }

    

    void Update() {
        timePassed = Time.time;
        checkGameState(playersAlive, enemiesAlive);
        if (Input.GetKeyDown("a")) {
            endLevel();
        }
    }

    private void UIElements() {
        levelText.text = "Level: " + currentLevel;
    }

    private void startLevel(uint currentLevel) {
        healthItemsAlreadyDropped = 0;
        spawnEnemies(minionSpawnAmount, monsterSpawnAmount, currentLevel);
        if (!playersSpawned) {
            spawnPlayers();
            playersSpawned = true;  
        }
        
        UIElements();
    }

    private void generateRandomElement() {
        int rNumb = Random.Range(0, 3);
        List<string> randomElements = new List<string> { "fire", "water", "earth" };
        randomElements.RemoveAt(rNumb);
        element1 = randomElements[0];
        element2 = randomElements[1];
    }

    private void spawnEnemies(uint minionSpawnAmount, uint monsterSpawnAmount, uint currentLevel) {
        
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
            generateRandomElement();
            if (Random.Range(0, 2) == 0) {
                element = element1;
            } else {
                element = element2;
            }
            if (element == "fire") {
                Temporary_Enemy_Handler = Instantiate(FireMinionPrefab, EnemySpawnPos[randomPos[i]].transform.position, EnemySpawnPos[randomPos[i]].transform.rotation) as GameObject;
                Temporary_Enemy_Handler.GetComponent<Minion>().element = element;
            } else if (element == "water") {
                Temporary_Enemy_Handler = Instantiate(WaterMinionPrefab, EnemySpawnPos[randomPos[i]].transform.position, EnemySpawnPos[randomPos[i]].transform.rotation) as GameObject;
                Temporary_Enemy_Handler.GetComponent<Minion>().element = element;
            } else if (element == "earth") {
                Temporary_Enemy_Handler = Instantiate(EarthMinionPrefab, EnemySpawnPos[randomPos[i]].transform.position, EnemySpawnPos[randomPos[i]].transform.rotation) as GameObject;
                Temporary_Enemy_Handler.GetComponent<Minion>().element = element;
            }
            nextSpawnPoint++;
            enemyHasSpawned = true;
            enemiesAlive++;
        }

        for (int i = 0; i < monsterSpawnAmount; i++) {

            GameObject Temporary_Enemy_Handler;
            generateRandomElement();
            if (element1 == "fire" && element2 == "water" || element1 == "water" && element2 == "fire") {
                Temporary_Enemy_Handler = Instantiate(SteamMonsterPrefab, EnemySpawnPos[randomPos[i + nextSpawnPoint]].transform.position, EnemySpawnPos[randomPos[i + nextSpawnPoint]].transform.rotation) as GameObject;
                Temporary_Enemy_Handler.GetComponent<Monster>().element1 = element1;
                Temporary_Enemy_Handler.GetComponent<Monster>().element2 = element2;
            } else if (element1 == "fire" && element2 == "earth" || element1 == "earth" && element2 == "fire") {
                Temporary_Enemy_Handler = Instantiate(GlassMonsterPrefab, EnemySpawnPos[randomPos[i + nextSpawnPoint]].transform.position, EnemySpawnPos[randomPos[i + nextSpawnPoint]].transform.rotation) as GameObject;
                Temporary_Enemy_Handler.GetComponent<Monster>().element1 = element1;
                Temporary_Enemy_Handler.GetComponent<Monster>().element2 = element2;
            } else if (element1 == "earth" && element2 == "water" || element1 == "water" && element2 == "earth") {
                Temporary_Enemy_Handler = Instantiate(MudMonsterPrefab, EnemySpawnPos[randomPos[i + nextSpawnPoint]].transform.position, EnemySpawnPos[randomPos[i + nextSpawnPoint]].transform.rotation) as GameObject;
                Temporary_Enemy_Handler.GetComponent<Monster>().element1 = element1;
                Temporary_Enemy_Handler.GetComponent<Monster>().element2 = element2;
            }
            
            enemiesAlive++;
        }

    }

    private void spawnPlayers() {
        for (int i = 0; i < numberOfPlayers; i++) {
            GameObject Temporary_Player_Handler;
            if (i == 0) {
                Temporary_Player_Handler = Instantiate(FirePlayerPrefab, PlayerSpawnPos[i].transform.position, PlayerSpawnPos[i].transform.rotation) as GameObject;
                Players[i] = Temporary_Player_Handler;
            } else if (i == 1) {
                Temporary_Player_Handler = Instantiate(EarthPlayerPrefab, PlayerSpawnPos[i].transform.position, PlayerSpawnPos[i].transform.rotation) as GameObject;
                Players[i] = Temporary_Player_Handler;
            } else if (i == 2) {
                Temporary_Player_Handler = Instantiate(WaterPlayerPrefab, PlayerSpawnPos[i].transform.position, PlayerSpawnPos[i].transform.rotation) as GameObject;
                Players[i] = Temporary_Player_Handler;
            }
            playersAlive++;
        }
    }

    IEnumerator MyFunction(GameObject Players, int pos, float delayTime) {
        Players.transform.position = PlayerSpawnPos[pos].transform.position;
        GameLogic.playersAlive++;
        yield return new WaitForSeconds(delayTime);
        Players.SetActive(true);
        Players.GetComponent<Player>().alive = true;
        Players.GetComponent<Player>().currentHealth = Players.GetComponent<Player>().healthSlider.maxValue;
        Players.GetComponent<Player>().healthSlider.value = Players.GetComponent<Player>().currentHealth;
    }

    private void checkGameState(uint playersAlive, uint enemiesAlive) {
        for (int i = 0; i < Players.Length; i++) {
            if (Players[i] != null) { 
                if (!Players[i].GetComponent<Player>().alive) {
                    GameLogic.playersAlive--;
                    Players[i].SetActive(false);
                    StartCoroutine(MyFunction(Players[i], i, repspawnTime));
                }
            }
        }
        

        if (playersAlive == 0) {
            //Debug.Log("Time survived: " + Time.time);
            ///endLevel();
            //startLevel(currentLevel);
        }

        if (enemiesAlive == 0 && playersAlive != 0 && enemyHasSpawned) {
            for (int i = 0; i < Players.Length; i++) {
                if (Players[i] != null) {
                    StartCoroutine(MyFunction(Players[i], i, 1f));
                }
            }
            
            //enemyHasSpawned = false;
            //Debug.Log("Time survived: " + Time.time);
            //endLevel();
            //startLevel(currentLevel++);
        }
    }

    private void endLevel() {
        if (enemiesAlive != 0) {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
                Destroy(enemy);
                enemiesAlive--;
            }
        }

        if (playersAlive != 0) {
            foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
                //Destroy(player);
                //This shold reposition players.
            }
        }
    }
}
