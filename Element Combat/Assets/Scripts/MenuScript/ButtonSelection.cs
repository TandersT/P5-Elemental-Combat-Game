using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WindowsInput;


public class ButtonSelection : MonoBehaviour {
    GameObject lastselect;
    public EventSystem evento;
    public Image SelectionBox;
    [Range(-1, 1)]
    public float y;
    public float x;
    public bool attack;
    float buttonClick = 0.0f;
    float buttonNextClick = 0.5f;

    void Update() {
        if (EventSystem.current.currentSelectedGameObject == null) {
            EventSystem.current.SetSelectedGameObject(lastselect);
        } else {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }
        SelectionBox.transform.position = evento.currentSelectedGameObject.transform.position;
        if (Time.time > buttonClick) {
            buttonClick = Time.time + buttonNextClick;
            if (y > 0.5f) {
                InputSimulator.SimulateKeyPress(VirtualKeyCode.DOWN);
                Debug.Log("I happened");
            } else if (y < -0.5) {
                InputSimulator.SimulateKeyPress(VirtualKeyCode.UP);
            }
        }
        if (attack == true) {
            InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN);
        }
    }
}
