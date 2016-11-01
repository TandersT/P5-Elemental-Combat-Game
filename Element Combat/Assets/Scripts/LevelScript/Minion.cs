using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Enemy {
    public Collider ColliderMinion;
    public Collider ColliderPlayer;



    void meleeAttack(Collider ColliderPlayer, Collider ColliderMinion) {

    }

    void pathfinder(Vector3 Pos) {

    }
    
    void findNearestPlayer(Vector3[] playerPositions) {

    }

    void hit(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0.0f) {
            Destroy(gameObject);
        }
        Debug.Log(gameObject.name + ": " + currentHealth);
    }

    void OnCollisionEnter(Collision _collision) {
        if (_collision.gameObject.tag == "Bullet"){
            string elementAttacker = ShootProjectile.element;
            string element = "water";
            Debug.Log(elementAttacker);
            float damageAttacker = 10;
            float elementMultiplier = ElementTable.lookUpElementMultiplier(elementAttacker, element);
            Debug.Log(elementMultiplier);
	        float damage = damageAttacker * elementMultiplier;
            hit(damage);
        } 
    }

}
