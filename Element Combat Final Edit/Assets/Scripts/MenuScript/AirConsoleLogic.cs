using UnityEngine;
using UnityEngine.UI;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class AirConsoleLogic : MonoBehaviour {

    [SerializeField]
    private Toggle[] ConnectedPlayers;

    public bool attack = false;
    int active_player;
    public ButtonSelection bSelection;
    string currentScene;
    public GameLogic pSetup;
    public GameObject[] players = new GameObject[3];
    public Player[] pMovement = new Player[3];
    //public Text DebugText;
    public bool[] pressedJoystick = new bool[3];
    public bool[] pressedAttack = new bool[3];

    void Awake() {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
        bSelection = GameObject.FindGameObjectWithTag("Manager").GetComponent<ButtonSelection>();
    }

    void Start() {

    }

    void Update() {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Level" && pSetup == null) {
            pSetup = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameLogic>();
            players = pSetup.Players;
            for (int i = 0; i < players.Length; i++) {
                pMovement[i] = players[i].GetComponent<Player>();
            }
        }

    }

    void OnConnect(int device_id) {
        AirConsole.instance.SetActivePlayers(players.Length);
        if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0) {
            if (AirConsole.instance.GetControllerDeviceIds().Count >= 1) {
                //StartGame();
            } else {
                //No start game
            }
        }
    }

    void OnDisconnect(int device_id) {
        AmountOfPlayersConnected();
    }

    void OnMessage(int device_id, JToken data) {
        active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);
        menuScene("Menu", data);
        levelScene("Level", data);
    }


    void menuScene(string sceneName ,JToken data) {
        Debug.Log("Menu");
        if (currentScene == sceneName) {
            Debug.Log("Menu Loaded");
            if (data["joystick-left"] != null) {
                pressedJoystick[0] = (bool)data["joystick-left"]["pressed"];
                if (active_player == 0 && pressedJoystick[0]) {
                    bSelection.y = (float)data["joystick-left"]["message"]["y"];
                    bSelection.x = (float)data["joystick-left"]["message"]["x"];
                }
                if (pressedJoystick[0] == false) {
                    bSelection.x = 0;
                    bSelection.y = 0;
                }
            }
            if (data["attack"] != null) {
                bSelection.attack = (bool)data["attack"]["pressed"];
            }
        }
    }

    void levelScene(string sceneName, JToken data) {
        if (currentScene == sceneName) {
            if (data["joystick-left"] != null) {
                pressedJoystick[active_player] = (bool)data["joystick-left"]["pressed"];
                if (pressedJoystick[active_player]) {
                    pMovement[active_player].x = (float)data["joystick-left"]["message"]["x"];
                    pMovement[active_player].y = (float)data["joystick-left"]["message"]["y"];
                }
                if (pressedJoystick[active_player] == false) {
                    pMovement[active_player].x = 0;
                    pMovement[active_player].y = 0;
                }
            }
        }
   
        if (data["attack"] != null) {
            pressedAttack[active_player] = (bool)data["attack"]["pressed"];
            if (pressedAttack[active_player]) {
                pMovement[active_player].attacked = (bool)data["attack"]["pressed"];
            } else {
                pressedAttack[active_player] = false;
            }
        }
    }
    void AmountOfPlayersConnected() {
        for (int i = 0; i < 3; i++) {
            ConnectedPlayers[i].isOn = false;
        }
        //Toggles the P1, P2 & P3 connection detection on/off
        for (int i = 0; i < AirConsole.instance.GetControllerDeviceIds().Count; i++) {
            ConnectedPlayers[i].isOn = true;
        }
    }

    void OnDestroy() {

        // unregister airconsole events on scene change
        if (AirConsole.instance != null) {
            AirConsole.instance.onMessage -= OnMessage;
        }
    }

}
