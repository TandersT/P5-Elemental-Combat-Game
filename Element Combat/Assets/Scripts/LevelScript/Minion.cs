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

    void Awake() {

    }

    void Update() {
        if(Time.time > nextUpdate){
            nextUpdate = Time.time + updateRate;
            searchAndDestroy();
        }
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
        float distanceToNearestPlayer = float.MaxValue;
        float previousNearestFriend = float.MaxValue;
        float distanceToPlayer;
        float distanceToFriend = 0.0f;  
        Vector3 nearestPlayer = Vector3.zero;  
        Vector3 nearestFriend = Vector3.zero;  
        Vector3 position = gameObject.transform.position;

        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            distanceToPlayer = Vector3.Distance(position, player.transform.position);
            if (distanceToPlayer < distanceToNearestPlayer) {
                nearestPlayer = player.transform.position;
            }
            distanceToNearestPlayer = Vector3.Distance(position, nearestPlayer);
        }

        if(distanceToNearestPlayer < proximity){
            Debug.Log("Walking towards nearest player.");
            transform.position = Vector3.MoveTowards(position, nearestPlayer, movementSpeed);    
        } 
        else{
            float idle = Random.Range(0, maxIdleTime);
            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
                distanceToFriend = Vector3.Distance(position, enemy.transform.position);
                if (distanceToFriend < previousNearestFriend) {
                    nearestFriend = enemy.transform.position;
                }
                previousNearestFriend = Vector3.Distance(position, nearestPlayer);   
            }
            if(distanceToFriend < proximity){
                Debug.Log("Walking towards nearest friend.");

                if(Time.time > nextStop){
                    nextStop = Time.time + idle;                
                    transform.position = Vector3.MoveTowards(position, nearestFriend, 0.0f);   
                }else{
                    transform.position = Vector3.MoveTowards(position, nearestFriend, movementSpeed);   
                }
           }
        }   
    }
}
