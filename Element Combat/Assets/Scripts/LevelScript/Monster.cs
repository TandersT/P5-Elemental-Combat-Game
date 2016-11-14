using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character {
    private float healthElement1;
    private float healthElement2; 
    // private enum element{ fire, earth, water};
    private string element1 = "water";
    private string element2 = "fire";

    void OnCollisionEnter(Collision _collision) {
        if (_collision.gameObject.tag == "Bullet"){
            
            // variables from the player
            float baseDamage = _collision.gameObject.GetComponent<ProjectileScript>();
            string attackerElement = _collision.gameObject.GetComponent<ProjectileScript>().element;

            float damage1 = calculateDamage(attackerElement, element1);
            float damage2 = calculateDamage(attackerElement, element2);
            hit(damage1, damage2);
        }
    } 

    void hit(float damage1, float damage2) {   
        if(healthElement1 - damage1 < 0.0f) healthElement1 = 0.0f;
         else healthElement1 -= damage1;  
        if(healthElement2 - damage1 < 0.0f) healthElement2 = 0.0f;
         else healthElement2 -= damage2;                   
        if (healthElement1 <= 0.0f && healthElement2 <= 0.0f) Destroy(gameObject);
    }

    private float calculateDamage(string attackerElement, string element){
        float elementMultiplier = ElementTable.lookUpElementMultiplier(attackerElement, element);
        float damage = _collision.gameObject.GetComponent<DestroyObject>.baseDamage * elementMultiplier1;
        return damage;
    }
}
