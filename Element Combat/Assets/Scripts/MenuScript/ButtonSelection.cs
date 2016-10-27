using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonSelection : MonoBehaviour {
    GameObject lastselect;
    public EventSystem evento;
    public Image SelectionBox;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("b"))
            print("space key was pressed");
        if (EventSystem.current.currentSelectedGameObject == null) {
            EventSystem.current.SetSelectedGameObject(lastselect);
        } else {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }
        SelectionBox.transform.position = evento.currentSelectedGameObject.transform.position;
    }
}
