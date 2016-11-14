using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class Minion : Character {
    public Collider ColliderMinion;
    public Collider ColliderPlayer;

    void meleeAttack(Collider ColliderPlayer, Collider ColliderMinion) {}

    void pathfinder(Vector3 Pos) {}
=======
public class Minion : Enemy {

    void Awake() {
        
    }

    void pathfinder(Vector3 Pos) {

    }
>>>>>>> Stashed changes
    
    void findNearestPlayer(Vector3[] playerPositions) {}

    void hit(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0.0f) {
            Destroy(gameObject);
            gameObject.GetComponent<HealthItem>().dropHealthItem(GameLogic.currentLevel, GameLogic.healthItemDropRateWeight, GameLogic.healthItemHealAmountWeight, gameObject.transform.position);
            GameLogic.enemiesAlive--;
        }
        Debug.Log(gameObject.name + ": " + currentHealth);
    }

    void OnCollisionEnter(Collision _collision) {
        if (_collision.gameObject.tag == "Bullet"){
            string elementAttacker = _collision.gameObject.GetComponent<DestroyObject>().element;
            string element = "water";
            Debug.Log("Attack: " + elementAttacker);
            Debug.Log("Def: " + element);
            float damageAttacker = 10;
            float elementMultiplier = ElementTable.lookUpElementMultiplier(elementAttacker, element);
            Debug.Log(elementMultiplier);
	        float damage = damageAttacker * elementMultiplier;
            hit(damage);
        } 
    }

}
