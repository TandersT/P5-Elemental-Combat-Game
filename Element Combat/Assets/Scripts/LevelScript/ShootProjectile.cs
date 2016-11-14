using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShootProjectile : MonoBehaviour {

    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force;
    
    public GameObject owner;
    public GameObject target; //Only relevant for enemies
    public float baseDamage = 10;

    float fireRate = 0.5f;
    float nextFire = 0f;

    void Update() {
        if(Input.GetKeyDown("space") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            rangedAttack();
        }

    }

    void rangedAttack(){   
        //The Bullet instantiation happens here.
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
        if (owner.gameObject.tag == "Player") {
            Temporary_Bullet_Handler.GetComponent<ProjectileScript>().element = owner.GetComponent<Player>().element;
            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.  
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
            Temporary_RigidBody.AddRelativeForce(transform.up * Bullet_Forward_Force);
            //Temporary_RigidBody.AddRelativeForce(owner.transform.position * Bullet_Forward_Force);
        } else if(owner.gameObject.tag == "Enemy") {
            Temporary_Bullet_Handler.GetComponent<ProjectileScript>().element = owner.GetComponent<Minion>().element;
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
            Temporary_RigidBody.AddRelativeForce(target.transform.position * Bullet_Forward_Force);
        }   

        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
        
         //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
        Destroy(Temporary_Bullet_Handler, 3.0f);
    }
}