using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
    private float healthElement1;
    private float healthElement2; 
    private string element1 = "water";
    private string element2 = "fire";
    Collider _collision;
    [SerializeField]
    protected GameObject HealthItemPrefab;

    public Enemy(){
        private string generateRandomElement() {
            List<string> randomElements = new List<string> {"fire", "water", "earth"}; 
            randomElements.Add(1)
            randomElements.RemoveAt(Random.Range(0,2);
            element1 = randomElements[0];       
            element2 = randomElements[1];
        }
    }

    protected void hit(float damage1, float damage2) {
        healthElement1 = healthElement1 - damage1 < 0.0f ? 0.0f : healthElement1 - damage1;    
        healthElement2 = healthElement2 - damage2 < 0.0f ? 0.0f : healthElement2 - damage2;

        if (healthElement1 <= 0.0f && healthElement2 <= 0.0f){
			dropHealthItem(GameLogic.currentLevel, GameLogic.healthItemBaseDropRate, GameLogic.healthItemDropRateWeight, GameLogic.healthItemBaseHealAmount, GameLogic.healthItemHealAmountWeight, gameObject.transform.position);
 			Destroy(gameObject);
        	GameLogic.enemiesAlive--;
        }
    }

    protected void hit(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0.0f) {
			dropHealthItem(GameLogic.currentLevel, GameLogic.healthItemBaseDropRate, GameLogic.healthItemDropRateWeight, GameLogic.healthItemBaseHealAmount, GameLogic.healthItemHealAmountWeight, gameObject.transform.position);
            Destroy(gameObject);
		    GameLogic.enemiesAlive--;
        }
    }

    protected float calculateDamageTaken(string playerElement, float playerBaseDamage, string element){
        float elementMultiplier = ElementTable.lookUpElementMultiplier(playerElement, element);
        float damage = playerBaseDamage * elementMultiplier;
        return damage;
    }

    public void dropHealthItem(uint currentLevel, float healthItemBaseDropRate, float healthItemDropRateWeight, float healthItemBaseHealAmount, float healthItemHealAmountWeight, Vector3 dropPosition){
        float dropRate = healthItemBaseDropRate / (healthItemDropRateWeight * currentLevel);
        float healAmount = healthItemBaseHealAmount / (healthItemHealAmountWeight * currentLevel);

        if(dropRate >= Random.Range(0.0f, 100.0f)){
            GameObject Temporary_Health_Item;
            Temporary_Health_Item = Instantiate(HealthItemPrefab, dropPosition, Quaternion.identity) as GameObject;
            Temporary_Health_Item.GetComponent<HealthItemScript>().healAmount = healAmount;
        }
    }
}