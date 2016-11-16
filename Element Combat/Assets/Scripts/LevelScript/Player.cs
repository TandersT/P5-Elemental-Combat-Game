using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
//Fixed

public class Player : Character {

    private int playerID;
    private Vector3 facingDirection;
    private Rigidbody playerRB;
    public bool alive = true;
    //Movement test
    public bool charMove, charHit;
    public Slider healthSlider;
    private string[] healthSliders = new string[] { "P1HealthSlider", "P2HealthSlider", "P3HealthSlider"};
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;

    void Awake() {
        playerRB = GetComponent<Rigidbody>();
        healthSlider = GameObject.Find(healthSliders[playerID]).GetComponent<Slider>();
        element = "earth";
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        playerRB.freezeRotation = true;
        playerRB.useGravity = false;
        //Debug.Log("Attack: " + element);
    }

    void Update() {
        //Movement test
        transform.Translate(0f, 0f, movementSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Rotate(0f, movementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f);
        //Needs to be set true when walking occours
    }

    void FixedUpdate() {
        PlayerMovement();
    }


    void AnimationController() {
        //charMove
        //charHit
    }

    void PlayerMovement() {
        // Calculate how fast we should be moving
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= movementSpeed;

        if (targetVelocity == Vector3.zero) {
            charMove = false;
        } else {
            charMove = true;
        }

        // Apply a force that attempts to reach our target velocity
        Vector3 velocity = playerRB.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        playerRB.AddForce(velocityChange, ForceMode.VelocityChange);

        playerRB.AddForce(new Vector3(0, -gravity * playerRB.mass, 0));


    }
    void PlayerShoot() {

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
        healthSlider.value = currentHealth;
        print("Player currentHealth: " + currentHealth);
    }

    void OnCollisionEnter(Collision _collision) {
        if (_collision.gameObject.tag == "HealthItem") {
            changeHealth(_collision.gameObject.GetComponent<HealthItemScript>().healAmount);
        }
        if (_collision.gameObject.tag == "Enemy") {
            changeHealth(-_collision.gameObject.GetComponent<Minion>().baseDamage);
            charHit = true;
            Destroy(_collision.gameObject);
            GameLogic.enemiesAlive--;
        } else
            charHit = false;
    }
}
