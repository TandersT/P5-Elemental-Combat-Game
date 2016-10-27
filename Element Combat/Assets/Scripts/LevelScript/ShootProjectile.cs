using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour {
    private float projectileSpeed;
    private float baseDamage;
    private enum element { fire, earth, water };
    private Vector3 direction;
    private enum whoShotTheProjectile{ player, monster};
    public Collider projectileCollider;
    public Collider objectHitCollider;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    void damage(){
    }
    void remove() {

    }

}
