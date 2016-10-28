using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Enemy {
    public Collider ColliderMinion;
    public Collider ColliderPlayer;

    void changeHealth(float changeHealth) {
        if (currentHealth + changeHealth < 0.0f) {
            currentHealth = 0.0f;
            Destroy(gameObject);
        } else {
            currentHealth += changeHealth;
        }
        print("Minion currentHealth: " + currentHealth);
    }

    void meleeAttack(Collider ColliderPlayer, Collider ColliderMinion) {

    }

    void pathfinder(Vector3 Pos) {

    }
    
    void findNearestPlayer(Vector3[] playerPositions) {

    }
    void OnCollisionEnter(Collision _collision) {
        if (_collision.gameObject.tag == "Bullet")
            changeHealth(-11);
    }

}
