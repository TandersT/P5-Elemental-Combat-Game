using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion : Enemy {
    public GameObject targetObject;
    int count = 0;
    float walkTimer = 1;
    float walkNext = 1;
    float tempMovementspeed;

    void Awake() {
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
        float distanceToNearestPlayer = 9999999.9f;
        float previousNearestFriend = 9999999.9f;
        float distanceToPlayer, distanceToFriend;  
        Vector3 nearestPlayer = Vector3.zero;  
        Vector3 nearestFriend;  
        float proximity = 10.0f;
        Vector3 position = gameObject.transform.position;

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            distanceToPlayer = Vector3.Distance(position, player.transform.position);
            if (distanceToPlayer < distanceToNearestPlayer) {
                nearestPlayer = player.transform.position;
            }
            distanceToNearestPlayer = Vector3.Distance(position, nearestPlayer);
        }

        if(distanceToNearestPlayer > proximity){
            transform.position = Vector3.MoveTowards(position, nearestPlayer, movementSpeed);    
        } 
        else{
            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
                distanceToFriend = Vector3.Distance(position, enemy.transform.position);
                if (distanceToFriend < previousNearestFriend) {
                    nearestFriend = enemy.transform.position;
                }
                previousNearestFriend = Vector3.Distance(position, nearestPlayer);   
            }
        }
        
    }


    // hvis player er i proximity, gå mod player, 
    // ellers gå mod nearest enemy.
}
