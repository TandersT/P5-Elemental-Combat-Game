using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Character {

    void Awake() {
        
    }

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
            string elementAttacker = _collision.gameObject.GetComponent<ProjectileScript>().element;
            float baseDamage = _collision.gameObject.GetComponent<ProjectileScript>().baseDamage;
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
