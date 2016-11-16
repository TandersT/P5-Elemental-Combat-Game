using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Enemy {
    public string element1;
    public string element2;
    public float range = 10.0f;
    Vector3 nearestPlayer = Vector3.zero;

    void FixedUpdate() {
        searchAndDestroy();
    }

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
        float distanceToNearestPlayer = float.MaxValue;
        float distanceToPlayer;  
        Vector3 position = gameObject.transform.position;
 
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            distanceToPlayer = Vector3.Distance(position, player.transform.position);
            if (distanceToPlayer < distanceToNearestPlayer) {
                nearestPlayer = player.transform.position;
                distanceToNearestPlayer = Vector3.Distance(position, nearestPlayer);
            }
        }
        if(distanceToNearestPlayer > range){
            transform.position = Vector3.MoveTowards(position, nearestPlayer, movementSpeed);
        }
        else{
            rangedAttack();
        }
    }
}