using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour {
    public Collider ColliderMinion;
    public Collider ColliderPlayer;
   
	void changeHealth( float damage){
	
		//currentHealth -= damage;

		//if(health - damage < 0){
			//dropHealthItem(int healthItemDropChance, Vector3 characterPosition);
			//destroy the minion gameobject
		//}
	
	}

    void meleeAttack(Collider ColliderPlayer, Collider ColliderMinion) {

    }

    void pathfinder(Vector3 Pos) {

    }
    
    void findNearestPlayer(Vector3[] playerPositions) {

    }
}
