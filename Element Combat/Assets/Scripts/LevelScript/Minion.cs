using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Enemy {
    public Collider ColliderMinion;
    public Collider ColliderPlayer;

    void hit(float damage) {
       	currentHealth -= damage;
        if (currentHealth - damage < 0.0f) {
            Destroy(gameObject);
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

        if (_collision.gameObject.tag == "Bullet"){
//        	Debug.Log(_collision.gameObject.element);
  //      	float elementMultiplier = ElementTable.lookUpElementMultiplier(_collision.gameObject, element1);
	//        float damage = _collision.gameObject.baseDamage * elementMultiplier;
      //      hit(damage);

        }
        


        
    }

}
