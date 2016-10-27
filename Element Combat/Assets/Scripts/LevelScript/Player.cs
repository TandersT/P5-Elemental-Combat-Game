using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : Character {
    private int playerID;
    private Vector3 facingDirection;
    public bool alive;

    void Start() {

        
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            adjustElementMultiplierWeightWeak(elementMultiplierWeight);
            adjustElementMultiplierWeightStrong(elementMultiplierWeight);
            lookUpElementMultiplier(adjustElementMultiplierWeightWeak(elementMultiplierWeight),
            adjustElementMultiplierWeightStrong(elementMultiplierWeight), currentElementFloats);
            Debug.Log("Strong attack!: " + currentElementFloats[0]);
            for (int i = 0; i < currentElementFloats.Length; i++) {
                currentElementFloats[i] = initialElementFloats[i];
            }
        }
        if (Input.GetKeyDown(KeyCode.B)) {
            adjustElementMultiplierWeightWeak(elementMultiplierWeight);
            adjustElementMultiplierWeightStrong(elementMultiplierWeight);
            lookUpElementMultiplier(adjustElementMultiplierWeightWeak(elementMultiplierWeight),
            adjustElementMultiplierWeightStrong(elementMultiplierWeight), currentElementFloats);
            Debug.Log("Weak attack!: " + currentElementFloats[1]);
            for (int i = 0; i < currentElementFloats.Length; i++) {
                currentElementFloats[i] = initialElementFloats[i];
            }
        }
    }

    protected override float adjustElementMultiplierWeightStrong(float elementMultiplierWeight) {
        return base.adjustElementMultiplierWeightStrong(elementMultiplierWeight);
    }
    protected override float adjustElementMultiplierWeightWeak(float elementMultiplierWeight) {
        return base.adjustElementMultiplierWeightWeak(elementMultiplierWeight);
    }
    protected override void lookUpElementMultiplier(float strong, float weak, float[] elementFloats) {
        base.lookUpElementMultiplier(strong, weak, elementFloats);
    }

    void move(Vector3 endPosition, Vector3 playerPosition) {

    }
    void shoot(Vector3 facingDirection, Vector3 playerPosition) {

    }
    void changeHealth(float changeHealth) {

    }
}
