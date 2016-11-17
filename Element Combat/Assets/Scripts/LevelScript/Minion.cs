using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion : Enemy {
    public float proximity = 100.0f;
    public float nextUpdate = 0;
    public float updateRate = 1.0f;
    public float maxIdleTime = 5.0f;
    private float nextStop = 0.0f;
    public bool playerOverride = false;


    Vector3 nearestPlayer = Vector3.zero;
    Vector3 nearestFriend = Vector3.zero;

    void Awake() {

    }

    void FixedUpdate() {
        searchAndDestroy();
    }

    void OnCollisionEnter(Collision _collision) {
        if (_collision.gameObject.tag == "Bullet"){
            string elementAttacker = _collision.gameObject.GetComponent<ProjectileScript>().element;
            float damageAttacker = _collision.gameObject.GetComponent<ProjectileScript>().baseDamage;
            float damage = calculateDamageTaken(elementAttacker, damageAttacker, element);
            hit(damage);
        }
        if (_collision.gameObject.tag == "Enemy") {
            playerOverride = true;
        }
    }

    void searchAndDestroy(){
        Vector3 position = gameObject.transform.position;
        float distanceToNearestPlayer = float.MaxValue;
        float previousNearestFriend = float.MaxValue;
        float distanceToPlayer;
        float distanceToFriend;
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            distanceToPlayer = Vector3.Distance(position, player.transform.position);
            if (distanceToPlayer < distanceToNearestPlayer) {
                nearestPlayer = player.transform.position;
                distanceToNearestPlayer = distanceToPlayer;
            }
        }
                if (distanceToNearestPlayer < proximity || playerOverride == true) {
                    transform.position = Vector3.MoveTowards(position, nearestPlayer, movementSpeed);
                    EnemyMovement(nearestPlayer);
                }
        else {
            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
                if (enemy.transform.position == transform.position) break;
                distanceToFriend = Vector3.Distance(position, enemy.transform.position);
                if (distanceToFriend < previousNearestFriend) {
                    nearestFriend = enemy.transform.position;
                    previousNearestFriend = distanceToFriend;
                }
           }
            transform.position = Vector3.MoveTowards(position, nearestFriend, movementSpeed);
            EnemyMovement(nearestPlayer);
        }   
    }
}
