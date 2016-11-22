using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
//Fixed

public class Player : Character {

    private int playerID;
    [SerializeField]
    private Rigidbody playerRB;
    public bool alive = true;
    //Movement test
    public bool charMove, charHit;
    public Slider healthSlider;
    private string[] healthSliders = new string[] { "P1HealthSlider", "P2HealthSlider", "P3HealthSlider"};
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public GameObject playerModelDirection;
    public float x, y;
    public bool attacked = false;

    void Awake() {
        playerRB = GetComponentInChildren<Rigidbody>();
        healthSlider = GameObject.Find(healthSliders[playerID]).GetComponent<Slider>();
        alive = true;
        element = "earth";
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        playerRB.freezeRotation = true;
        playerRB.useGravity = false;
        //Debug.Log("Attack: " + element);
        currentHealth = maxHealth;

}

    void Update() {
        if (Input.GetKeyDown("space") || attacked == true ){
            rangedAttack();
        }
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
        //Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 targetVelocity = new Vector3(x, 0, y);
        targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= movementSpeed;

        charMove = targetVelocity == Vector3.zero ? false : true;

        // Apply a force that attempts to reach our target velocity
        Vector3 velocity = playerRB.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        if(charMove == true){
            playerModelDirection.transform.rotation = Quaternion.LookRotation(velocity);
        }
        playerRB.AddForce(velocityChange, ForceMode.VelocityChange);
        playerRB.AddForce(new Vector3(0, -gravity * playerRB.mass, 0));
    }

    void PlayerShoot() {

    }

    void changeHealth(float changeHealth) {
        // is it a health item?
        if(currentHealth + changeHealth > currentHealth){
            changeHealth = changeHealth * maxHealth / 100.0f;
        }

        currentHealth += changeHealth;

        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        } 
        else if(currentHealth <= 0.0f && alive == true) {
            currentHealth = 0.0f;
            alive = false;
            GameLogic.playersAlive--;
            Destroy(gameObject);
            Debug.Log("Players: " + GameLogic.playersAlive);
        }
        healthSlider.value = currentHealth;
    }

    void OnCollisionEnter(Collision _collision) {
        if (_collision.gameObject.tag == "HealthItem") {
            changeHealth(_collision.gameObject.GetComponent<HealthItemScript>().healAmount);
        }
        if (_collision.gameObject.tag == "Enemy") {
            if (_collision.gameObject.GetComponent<Minion>() != null) {
                changeHealth(-_collision.gameObject.GetComponent<Minion>().baseDamage);
                charHit = true;
                Destroy(_collision.gameObject);
                GameLogic.enemiesAlive--;
            }
        } else
            charHit = false;
        if (_collision.gameObject.tag == "Bullet") {
            string elementAttacker1 = _collision.gameObject.GetComponent<ProjectileScript>().element;
                string elementAttacker2 = _collision.gameObject.GetComponent<ProjectileScript>().element2;
            float damageAttacker = _collision.gameObject.GetComponent<ProjectileScript>().baseDamage;
            float damage1 = calculateDamageTaken(elementAttacker1, damageAttacker, element);
            float damage2 = calculateDamageTaken(elementAttacker2, damageAttacker, element);
                changeHealth(-damage1);
                changeHealth(-damage2);
            charHit = true;
            }
        }
}
