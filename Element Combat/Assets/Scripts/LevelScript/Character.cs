using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Character : MonoBehaviour {
    [SerializeField]
    protected float maxHealth, movementSpeed;
    public float currentHealth, baseDamage;
    public string element;
    protected ShootProjectile bulletElement;
    protected ElementTable elementTable;
    protected ShootProjectile shootProjectile;

    public GameObject ProjectileSpawn;
    public GameObject ProjectilePrefab;
    public float force;
    
    public GameObject Owner;

    protected float fireRate = 0.5f;
    protected float nextFire = 0.0f;

    Vector3 nearestPlayer = Vector3.zero;
    float previousNearestPlayer = float.MaxValue;

    protected void rangedAttack(){
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            //The Bullet instantiation happens here.
            GameObject Projectile;
            Projectile = Instantiate(ProjectilePrefab, ProjectileSpawn.transform.position, ProjectileSpawn.transform.rotation) as GameObject;
            if (Owner.gameObject.tag == "Player") {
                Projectile.GetComponent<ProjectileScript>().element = Owner.GetComponent<Player>().element;
                Projectile.GetComponent<ProjectileScript>().baseDamage = Owner.GetComponent<Player>().baseDamage;
                //Physics.IgnoreCollision(Projectile.GetComponent<Collider>(), GetComponent<Collider>());
                //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                Rigidbody ProjectileRigidBody;
                ProjectileRigidBody = Projectile.GetComponent<Rigidbody>();
                //Tell the bullet to be "pushed" forward by an amount set by force.  
                Projectile.transform.Rotate(Vector3.left * 90);
                ProjectileRigidBody.AddRelativeForce(transform.up * force);
                //ProjectileRigidBody.AddRelativeForce(Owner.transform.position * force);
            } else if (Owner.gameObject.tag == "Enemy") {
                Vector3 position = gameObject.transform.position;
                Projectile.GetComponent<ProjectileScript>().element = Owner.GetComponent<Monster>().element;
                //Physics.IgnoreCollision(Projectile.GetComponent<Collider>(), GetComponent<Collider>());
                foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
                    float distanceToPlayer = Vector3.Distance(position, player.transform.position);
                    if (distanceToPlayer < previousNearestPlayer) {
                        nearestPlayer = player.transform.position;
                        previousNearestPlayer = distanceToPlayer;
                    }
                    Rigidbody ProjectileRigidBody;
                    ProjectileRigidBody = Projectile.GetComponent<Rigidbody>();
                    ProjectileRigidBody.AddRelativeForce(transform.up * force);
                }
            }
            Destroy(Projectile, 3.0f);
        }
    }
}
