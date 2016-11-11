using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour {
    [Range (0.0f,100.0f)]
    public float maxHealAmount;
    [Range (0.0f,100.0f)]
    public float maxDropRate;

	void dropHealthItem(uint currentLevel){
		float dropRate = maxHealAmount / (healthItemDropRateWeight * level);
		float healAmount = maxDropRate / (healthItemHealAmountWeight * level);
	}
	
    void remove() {
    	// call this method when the healhpack is picked up
    }
}
