using UnityEngine;
using System.Collections;

public class HealthItemScript : MonoBehaviour {
	public float healAmount;
    void OnCollisionEnter(Collision colTarget) {
        if (colTarget.gameObject.tag == "Player"){

            Debug.Log(healAmount);
            DestroyObject(gameObject);

        }
    }
}
