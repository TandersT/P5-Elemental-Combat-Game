using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float movementSpeed;
    [SerializeField]
    protected float health;
    protected Vector3 characterPosition;
    public enum element{fire = 1, earth = 1, water = 1};
    
    protected float[] elementsFloats = { 1, 1};
    protected int[] elementsInts = { 1, 1 };

    public float[,] elementTable = new float[3, 3];
    [Range(0, 1)]
    public float elementMultiplierWeight = 0.5f;
    private float elementMultiplierWeak, elementMultiplierStrong;
    
    void Start() {
        
    }


    private void Update() {
        adjustElementMultiplierWeightWeak(elementMultiplierWeight);
        adjustElementMultiplierWeightStrong(elementMultiplierWeight);
        lookUpElementMultiplier(hitElement, attackElement, adjustElementMultiplierWeightWeak(elementMultiplierWeight),
        adjustElementMultiplierWeightStrong(elementMultiplierWeight), elementsFloats, elementsInts);
    }

    protected virtual float adjustElementMultiplierWeightWeak(float elementMultiplierWeight) {
        return elementMultiplierWeak = 1 - elementMultiplierWeight;
    }

    protected virtual float adjustElementMultiplierWeightStrong(float elementMultiplierWeight) {
        return elementMultiplierStrong = elementMultiplierWeight;
    }

    protected virtual void lookUpElementMultiplier(element attacker, element hitter, float strong, float weak, float[] elementFloats, int[] elementInts) {
        elementInts[0] = (int)attacker;
        elementInts[1] = (int)hitter;
        elementFloats[0] = elementInts[0] * strong;
        elementFloats[1] = elementInts[1] * weak;
            Debug.Log(elementFloats[0] - elementFloats[1]);
    }
}
