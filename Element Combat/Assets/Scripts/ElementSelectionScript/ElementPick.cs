using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementPick : MonoBehaviour {
    //Makes the user able to change between elements, bu pressing buttons
    //This code should def. be remade, since right now it makes for a lot of repition.
    public Button FireTest;
    public Button WaterTest;
    public Button EarthTest;
    public Image FireImg;
    public Image WaterImg;
    public Image EarthImg;

    public Image CurrentImage;

    void Start() {
        //Listens for when the buttons is clicked
        FireTest.onClick.AddListener(TaskOnClickFire);
        WaterTest.onClick.AddListener(TaskOnClickWater);
        EarthTest.onClick.AddListener(TaskOnClickEarth);
    }

    //Whenever fire button is clicked do...
    //It disables the current active image, enables the pressed one instead(This case fire), and sets fire as current image.
    void TaskOnClickFire() {
        CurrentImage.enabled = false;
        FireImg.enabled = true;
        CurrentImage = FireImg;
    }
    //--||-- water
    void TaskOnClickWater() {
        CurrentImage.enabled = false;
        WaterImg.enabled = true;
        CurrentImage = WaterImg;
    }
    //--||-- earth
    void TaskOnClickEarth() {
        CurrentImage.enabled = false;
        EarthImg.enabled = true;
        CurrentImage = EarthImg;
    }
}
