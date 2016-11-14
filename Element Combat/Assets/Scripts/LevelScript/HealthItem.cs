using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour {
    [Range (0.0f,100.0f)]
    public float maxHealAmount = 100.0f;
    float dropRate, healAmount;
    [Range (0.0f,100.0f)]
    public float maxDropRate = 100.0f;
    public GameObject HealthItemPrefab;

    public void dropHealthItem(uint currentLevel, float healthItemDropRateWeight, float healthItemHealAmountWeight, Vector3 dropPosition){
        dropRate = maxDropRate / (healthItemDropRateWeight * currentLevel);
        healAmount = maxHealAmount / (healthItemHealAmountWeight * currentLevel);

        if(dropRate >= Random.Range(0.0f,100.0f)){
            GameObject Temporary_Health_Item;
            Temporary_Health_Item = Instantiate(HealthItemPrefab, dropPosition, Quaternion.identity) as GameObject;
            Temporary_Health_Item.GetComponent<HealthItemScript>().healAmount = healAmount;
        }
    }
}
