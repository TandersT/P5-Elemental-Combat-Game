using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShootProjectile : MonoBehaviour {

    public GameObject ProjectileSpawn;
    public GameObject ProjectilePrefab;
    public float force;
    
    public GameObject Owner;
    public GameObject Target; //Only relevant for enemies
    public float baseDamage = 10;

    float fireRate = 0.5f;
    float nextFire = 0.0f;

    void Update() {
    	if(Input.GetKeyDown("space") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            rangedAttack();
       	}
    }

    void rangedAttack(){   
        //The Bullet instantiation happens here.
        GameObject Projectile;
        Projectile = Instantiate(ProjectilePrefab, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation) as GameObject;
        if (Owner.gameObject.tag == "Player") {
            Projectile.GetComponent<ProjectileScript>().element = Owner.GetComponent<Player>().element;
            Projectile.GetComponent<ProjectileScript>().baseDamage = Owner.GetComponent<Player>().baseDamage;
            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody ProjectileRigidBody;
            ProjectileRigidBody = Projectile.GetComponent<Rigidbody>();
            //Tell the bullet to be "pushed" forward by an amount set by force.  
            Projectile.transform.Rotate(Vector3.left * 90);
            ProjectileRigidBody.AddRelativeForce(transform.up * force);
            //ProjectileRigidBody.AddRelativeForce(Owner.transform.position * force);
        } else if(Owner.gameObject.tag == "Enemy") {
            Projectile.GetComponent<ProjectileScript>().element = Owner.GetComponent<Minion>().element;
            Rigidbody ProjectileRigidBody;
            ProjectileRigidBody = Projectile.GetComponent<Rigidbody>();
            Projectile.transform.Rotate(Vector3.left * 90);
            ProjectileRigidBody.AddRelativeForce(Target.transform.position * force);
        }   

        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
        
         //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
        Destroy(Projectile, 3.0f);
    }
}