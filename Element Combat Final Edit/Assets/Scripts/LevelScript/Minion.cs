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
    public bool attackingPlayer = false;
    Rigidbody rb;
    Collider cl;

    Vector3 nearestPlayer = Vector3.zero;
    Vector3 nearestFriend = Vector3.zero;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        cl = GetComponentInChildren<Collider>();
    }

    void FixedUpdate() {
        if (!attackingPlayer) {
            searchAndDestroy();
        } else {
            rb.velocity = Vector3.zero;
            Invoke("AttackPlayer", 2);
        }
    }

    void OnCollisionEnter(Collision _collision) {
        if (_collision.gameObject.tag == "Bullet"){
            string elementAttacker = _collision.gameObject.GetComponent<ProjectileScript>().element;
            float damageAttacker = _collision.gameObject.GetComponent<ProjectileScript>().baseDamage;
            Debug.Log("Attack: " + elementAttacker + "def: " + element);
            float damage = calculateDamageTaken(elementAttacker, damageAttacker, element);
            hit(damage);
        }

		if (_collision.gameObject.tag == "Player") {
            attackingPlayer = true;
		}
        if (_collision.gameObject.tag == "Wall") {
            Physics.IgnoreCollision(_collision.gameObject.GetComponent<Collider>(), cl, true);
        }

    }

	void AttackPlayer () {
        attackingPlayer = false;
	}

    void searchAndDestroy(){
        Vector3 position = transform.position;
        float distanceToNearestPlayer = float.MaxValue;
        float distanceToPlayer;
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            distanceToPlayer = Vector3.Distance(position, player.transform.position);
            if (distanceToPlayer < distanceToNearestPlayer) {
                nearestPlayer = player.transform.position;
                distanceToNearestPlayer = distanceToPlayer;
            }
        }
        nearestPlayer.y = 35;
        Vector3 nextPos = Vector3.MoveTowards(position, nearestPlayer, movementSpeed);
        Vector3 speedForNextPos = (nextPos - transform.position).normalized * movementSpeed;
        rb.velocity = speedForNextPos;
        //else {
        //    foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
        //        if (enemy.transform.position == transform.position) break;
        //        distanceToFriend = Vector3.Distance(position, enemy.transform.position);
        //        if (distanceToFriend < previousNearestFriend) {
        //            nearestFriend = enemy.transform.position;
        //            previousNearestFriend = distanceToFriend;
        //        }
        //   }
        //    transform.position = Vector3.MoveTowards(position, nearestFriend, movementSpeed);
        //    EnemyMovement(nearestPlayer);
        //}   
    }
}
