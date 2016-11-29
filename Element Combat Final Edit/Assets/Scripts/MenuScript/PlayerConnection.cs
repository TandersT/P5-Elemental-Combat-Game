using UnityEngine;
using UnityEngine.UI;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class PlayerConnection : MonoBehaviour {
    [SerializeField]
    private Toggle[] ConnectedPlayers;
    //private float[] lel = new float {1, 2, 3};

    void Awake() {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
    }

    void OnConnect(int device_id) {
        if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0) {
            if (AirConsole.instance.GetControllerDeviceIds().Count >= 1) {
                AmountOfPlayersConnected();
            }
        }
    }

    void OnDisconnect(int device_id) {
        Debug.Log("Someone disconnected");
                AmountOfPlayersConnected();
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

    void OnMessage(int device_id, JToken data) {
        int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);
        if (active_player != -1) {
            if (active_player == 0) {
//Something eventsystem move
            }
        }
    }
}
