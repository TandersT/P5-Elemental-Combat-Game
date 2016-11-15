using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("Attack: " + elementAttacker);
            Debug.Log("Def: " + element);
            float elementMultiplier = ElementTable.lookUpElementMultiplier(elementAttacker, element);
            Debug.Log(elementMultiplier);
	        float damage = damageAttacker * elementMultiplier;
            hit(damage);
        } 
    }

}
