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
    protected string element;
    protected Vector3 characterPosition;

    protected void Start() {
        currentHealth = maxHealth;
    }
}