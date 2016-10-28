using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Character : MonoBehaviour {
    [SerializeField]
    protected float maxHealth;
    [SerializeField]
    protected float currentHealth;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float movementSpeed;
    protected Vector3 characterPosition;
    protected float[] initialElementFloats = { 2, 2, 2 };
    protected float[] currentElementFloats = {2, 2, 2};

    public float[,] elementTable = new float[3, 3];
    [Range(0, 1)]
    public float elementMultiplierWeight = 0.5f;
    private float elementMultiplierWeak, elementMultiplierStrong;
    
    protected void Start() {
        currentHealth = maxHealth;
    }

    protected virtual float adjustElementMultiplierWeightWeak(float elementMultiplierWeight) {
        return elementMultiplierWeak = 1 - elementMultiplierWeight;
    }

    protected virtual float adjustElementMultiplierWeightStrong(float elementMultiplierWeight) {
        return elementMultiplierStrong = elementMultiplierWeight;
    }

    protected virtual void lookUpElementMultiplier(float strong, float weak, float[] elementFloats) {
        elementFloats[0] *= strong;
        elementFloats[1] *= weak;
        
    }
}