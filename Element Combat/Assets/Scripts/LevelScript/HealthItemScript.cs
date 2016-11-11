using UnityEngine;
using System.Collections;

public class HealthItemScript : MonoBehaviour {
	public float healAmount;
	public void Update(){
		Debug.Log("Healing: " + healAmount);
	}
    void OnCollisionEnter(Collision colTarget) {
    	if(colTarget.gameObject.tag == "Player"){
    		DestroyObject(gameObject);
        	Debug.Log("HealthItem was destroyed");	
    	}
    }
}
