using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion : Enemy {

    Vector3 pos;
    Vector3 target;
    public GameObject targetObject;
    int count = 0;
    float distPrev, dist;
    float walkTimer = 1;
    float walkNext = 1;
    float tempMovementspeed;

    void Awake() {
    }

    void Update() {
        pos = transform.position;
        foreach (GameObject playerPos in GameObject.FindGameObjectsWithTag("Player")) {
            dist = Vector3.Distance(pos, playerPos.transform.position);
            
                target = playerPos.transform.position;
            
            distPrev = Vector3.Distance(pos, target);
        }
        //if (Time.time < walkTimer) {
        //    walkTimer = Time.time + walkNext;
        //    tempMovementspeed = movementSpeed;
        //    movementSpeed = 0;
        //} else
        //    movementSpeed = tempMovementspeed;

        transform.position = Vector3.MoveTowards(pos, target, movementSpeed);
    }

    void OnCollisionEnter(Collision _collision) {
        if (_collision.gameObject.tag == "Bullet"){
            string elementAttacker = _collision.gameObject.GetComponent<ProjectileScript>().element;
            float damageAttacker = _collision.gameObject.GetComponent<ProjectileScript>().baseDamage;
            float damage = calculateDamageTaken(elementAttacker, damageAttacker, element);
            hit(damage);
        } 
    }

     private void searchAndDestroy(){
        Vector3 previousNearestPlayer = 9999999;
        Vector3 previousNearestFriend = 9999999;
        float distanceToPlayer, distanceToFriend;  
        Vector3 nearestPlayer, nearestFriend;  
        float proximity = 10.0f;

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            distanceToPlayer = Vector3.Distance(position, player.transform.position);
            if (distanceToPlayer < previousNearestPlayer) {
                nearestPlayer = player.transform.position;
            }
            previousNearestPlayer = Vector3.Distance(position, nearestPlayer);
        }

        if(target > proximity){
            transform.position = Vector3.MoveTowards(position, target, movementSpeed);    
        } 
        else{
            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
                distance = Vector3.Distance(position, player.transform.position);
                if (distance < distancePrevious) {
                    nearestFriend = player.transform.position;
                }
                previousNearestFriend = Vector3.Distance(position, target);   
            }
        }
        
    }


    // hvis player er i proximity, gå mod player, 
    // ellers gå mod nearest enemy.
}
