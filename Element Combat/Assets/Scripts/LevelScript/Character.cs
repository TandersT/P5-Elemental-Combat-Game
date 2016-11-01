using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Character : MonoBehaviour {
    [SerializeField]
    protected float maxHealth;
    [SerializeField]
    public float currentHealth;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float movementSpeed;
    protected string element;
    protected Vector3 characterPosition;
    protected ShootProjectile bulletElement;
    [SerializeField]
    protected ElementTable elementTable;
    [SerializeField]
    protected ShootProjectile shootProjectile;

    protected void Start() {
        currentHealth = maxHealth;

    }
}