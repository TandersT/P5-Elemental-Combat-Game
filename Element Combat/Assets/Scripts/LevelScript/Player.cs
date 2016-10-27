using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    private int playerID;
    private Vector3 facingDirection;
    public bool alive;

    void Start() {
        element hitElement;
        element attackElement;
        hitElement = element.fire;
        Debug.Log(hitElement);
    }

    void Update() {
        adjustElementMultiplierWeightWeak(elementMultiplierWeight);
        adjustElementMultiplierWeightStrong(elementMultiplierWeight);
        lookUpElementMultiplier(hitElement, attackElement, adjustElementMultiplierWeightWeak(elementMultiplierWeight),
        adjustElementMultiplierWeightStrong(elementMultiplierWeight), elementsFloats, elementsInts);
    }

    protected override float adjustElementMultiplierWeightStrong(float elementMultiplierWeight) {
        return base.adjustElementMultiplierWeightStrong(elementMultiplierWeight);
    }
    protected override float adjustElementMultiplierWeightWeak(float elementMultiplierWeight) {
        return base.adjustElementMultiplierWeightWeak(elementMultiplierWeight);
    }
    protected override void lookUpElementMultiplier(element attacker, element hitter, float strong, float weak, float[] elementFloats, int[] elementInts) {
        base.lookUpElementMultiplier(attacker, hitter, strong, weak, elementFloats, elementInts);
    }

    void move(Vector3 endPosition, Vector3 playerPosition) {

    }
    void shoot(Vector3 facingDirection, Vector3 playerPosition) {

    }
    void changeHealth(float changeHealth) {

    }
}
