using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player : Character {

    private int playerID;
    private Vector3 facingDirection;
    public bool alive = true;
    //Movement test
    public static bool charMove;
    public float moveSpeed;

    void Awake() {
        element = "earth";
        //Debug.Log("Attack: " + element);
    }

    void Update() {
        //Movement test
        transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Rotate(0f, moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f);
        //Needs to be set true when walking occours
        if (true) {
            charMove = true;
        } else
            charMove = false;
    }


    void move(Vector3 endPosition, Vector3 playerPosition) {

    }
    void shoot(Vector3 facingDirection, Vector3 playerPosition) {

    }

    void changeHealth(float changeHealth) {
        if (currentHealth + changeHealth > maxHealth) {
            currentHealth = maxHealth;
        } else if (currentHealth + changeHealth < 0.0f) {
            currentHealth = 0.0f;
            alive = false;
            GameLogic.playersAlive--;
        } else {
            currentHealth += changeHealth;
        }
        print("Player currentHealth: " + currentHealth);
    }

    void OnCollisionEnter(Collision _collision) {
        if (_collision.gameObject.tag == "HealthItem") {
            changeHealth(_collision.gameObject.GetComponent<HealthItemScript>().healAmount);
        }
    }
}
