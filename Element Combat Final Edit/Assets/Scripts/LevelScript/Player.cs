using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
//Fixed

public class Player : Character {

    public Animator anim;
    public int playerID;
    [SerializeField]
    private Rigidbody playerRB;
    public bool alive = true;
    //Movement test
    public bool charMove, charHit, charAttack;
    public Slider healthSlider;
    private string[] healthSliders = new string[] { "P1HealthSlider", "P2HealthSlider", "P3HealthSlider"};
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public GameObject playerModelDirection;
    public float x, y;
    public bool attacked = false;
    public Color hpColor;
    public Image Fill;

    void Awake() {
        playerRB = GetComponentInChildren<Rigidbody>();
        healthSlider = GameObject.Find(healthSliders[playerID]).GetComponent<Slider>();
        Fill = healthSlider.GetComponentInChildren<Image>();
        Fill.color = hpColor;
        alive = true;
        element = "earth";
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        playerRB.freezeRotation = true;
        playerRB.useGravity = false;
        //Debug.Log("Attack: " + element);
        currentHealth = maxHealth;

}
     void Start() {
        
    }

    void Update() {
        AnimationController();
        if (Input.GetKeyDown("space") || attacked == true ){
            rangedAttack();
            attacked = false;
        }
        charHit = false;
        
        //Needs to be set true when walking occours
    }

    void FixedUpdate() {
        PlayerMovement();
    }


    void AnimationController() {
        if (charHit) {
            anim.SetTrigger("hit");
        }
        if (attacked) {
            anim.SetTrigger("attack");
        }
        if (charMove) {
            anim.SetTrigger("walk");
        }
    }

    void PlayerMovement() {
        // Calculate how fast we should be moving
        //Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 startPos = transform.position;
        Vector3 targetVelocity = new Vector3(x, 0, -y);
        targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= movementSpeed;
        
        charMove = targetVelocity == Vector3.zero ? false : true;

        // Apply a force that attempts to reach our target velocity
        Vector3 velocity = playerRB.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;

        if (charMove == true) {
            Vector3 rotationDirection = targetVelocity;
            Quaternion rotation = Quaternion.LookRotation(rotationDirection);
            Vector3 rotationSet = Quaternion.Lerp(playerModelDirection.transform.rotation, rotation, Time.deltaTime * 50).eulerAngles;
            playerModelDirection.transform.rotation = Quaternion.Euler(0f, rotationSet.y, 0f);
        }

        playerRB.AddForce(velocityChange, ForceMode.VelocityChange);
        playerRB.AddForce(new Vector3(0, -gravity * playerRB.mass, 0));
        Vector3 endPos = transform.position;

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
        } else if (currentHealth <= 0.0f && alive == true) {
            currentHealth = 0.0f;
            alive = false;
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

            }
        }   
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
