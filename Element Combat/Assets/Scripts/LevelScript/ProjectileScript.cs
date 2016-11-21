using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public string element;
    public string element2;
    public float baseDamage;
    void OnCollisionEnter(Collision colTarget) {
        if (colTarget.gameObject.tag == "Enemy" || colTarget.gameObject.tag == "Wall" || colTarget.gameObject.tag == "Player") {
            DestroyObject(gameObject);
        }
        if (colTarget.gameObject.tag == "Bullet") {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), colTarget.collider, true);
        }
    }
}
