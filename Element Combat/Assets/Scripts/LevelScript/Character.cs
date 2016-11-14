using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Character : MonoBehaviour {
    protected float maxHealth, movementSpeed;
    public float currentHealth, baseDamage;    
    public string element;
    protected Vector3 characterPosition;
    protected ShootProjectile bulletElement;
    protected ElementTable elementTable;
    protected ShootProjectile shootProjectile;

    protected void Start() {
        currentHealth = maxHealth;
    }
}