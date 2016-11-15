using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Enemy {
    private float healthElement1;
    private float healthElement2; 
    private string element1 = "water";
    private string element2 = "fire";
    Collider _collision;

    void OnCollisionEnter(Collision _collision) {
        if (_collision.gameObject.tag == "Bullet"){
            
            // variables from the player
            float playerBaseDamage = _collision.gameObject.GetComponent<ProjectileScript>().baseDamage;
            string playerElement = _collision.gameObject.GetComponent<ProjectileScript>().element;
            float damage1 = calculateDamageTaken(playerElement, playerBaseDamage, element1);
            float damage2 = calculateDamageTaken(playerElement, playerBaseDamage, element2);
            hit(damage1, damage2);
        }
    } 
}