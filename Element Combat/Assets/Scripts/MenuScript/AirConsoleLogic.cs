using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class AirConsoleLogic : MonoBehaviour {

#if !DISABLE_AIRCONSOLE
    void Awake() {
        // register events
        
    }	

    void Start() {
    }
	// Update is called once per frame
	void Update () {
        
    }

    void OnDestroy() {

        // unregister events
        if (AirConsole.instance != null) {
        }
    }
#endif
}
