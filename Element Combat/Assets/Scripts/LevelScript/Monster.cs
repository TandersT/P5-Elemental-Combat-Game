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

     private void searchAndDestroy(){
        Vector3 distancePrevious = 0;
        Vector3 distance;  
        Vector3 target;  

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            distance = Vector3.Distance(position, player.transform.position);
            if (distance < distancePrevious) {
                target = player.transform.position;
            }
            distancePrevious = Vector3.Distance(position, target);
        }
        
        distance > range ? move(target) : rangedAttack();
    }

    private void move(Vector3 target){
        transform.position = Vector3.MoveTowards(position, target, movementSpeed);
    }
}