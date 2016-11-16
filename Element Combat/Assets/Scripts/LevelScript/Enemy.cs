using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character {
    private float healthElement1;
    private float healthElement2; 
    private string element1, element2;
    Collider _collision;
    [SerializeField]
    protected GameObject HealthItemPrefab;
    public float range = 10;
    [SerializeField]
    protected Slider healthSlider;

    public Enemy(int randomNumber){
        List<string> randomElements = new List<string> {"fire", "water", "earth"};
        randomElements.RemoveAt(randomNumber);
        element1 = randomElements[0];       
        element2 = randomElements[1];
    }

    public Enemy(){
        
    }

     void Awake() {
    }

    protected void hit(float damage1, float damage2) {
        healthElement1 = healthElement1 - damage1 < 0.0f ? 0.0f : healthElement1 - damage1;    
        healthElement2 = healthElement2 - damage2 < 0.0f ? 0.0f : healthElement2 - damage2;

        if (healthElement1 <= 0.0f && healthElement2 <= 0.0f){
            dropHealthItem(gameObject.transform.position);
            Destroy(gameObject);
            GameLogic.enemiesAlive--;
        }
        healthSlider.value = currentHealth;
    }

    protected void hit(float damage) {
        if (currentHealth == maxHealth) {
            healthSlider = gameObject.GetComponentInChildren<Slider>();
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
    }

        currentHealth -= damage;
        if (currentHealth <= 0.0f) {
            dropHealthItem(gameObject.transform.position);
            Destroy(gameObject);
            GameLogic.enemiesAlive--;
        }
        healthSlider.value = currentHealth;
    }

    protected float calculateDamageTaken(string playerElement, float playerBaseDamage, string element){
        float elementMultiplier = ElementTable.lookUpElementMultiplier(playerElement, element);
        float damage = playerBaseDamage * elementMultiplier;
        return damage;
    }

    public void dropHealthItem( Vector3 dropPosition){
        float healAmount = GameLogic.healthItemBaseHealAmount / (GameLogic.healthItemHealAmountWeight * GameLogic.currentLevel);
        float dropChance = getDropChance(GameLogic.healthItemDropsForLevel, GameLogic.healthItemsAlreadyDropped);

        if(dropChance >= Random.Range(0.0f, 100.0f)){
            GameObject Temporary_Health_Item;
            Temporary_Health_Item = Instantiate(HealthItemPrefab, dropPosition, Quaternion.identity) as GameObject;
            Temporary_Health_Item.GetComponent<HealthItemScript>().healAmount = healAmount;
            float healthItemsAlreadyDropped = GameLogic.healthItemsAlreadyDropped;
        }
    }

    private float getDropChance(uint healthItemDropsForLevel, uint healthItemsAlreadyDropped){
        uint possibleDropsLeft = GameLogic.enemiesAlive;
        uint remainingHealthItemDrops = healthItemDropsForLevel - healthItemsAlreadyDropped;
        float dropChance = possibleDropsLeft / remainingHealthItemDrops;
        return dropChance;
    }
}