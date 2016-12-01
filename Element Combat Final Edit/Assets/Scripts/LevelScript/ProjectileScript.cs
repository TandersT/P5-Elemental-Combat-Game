using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public string element;
    public string element2;
    public float baseDamage;
    void OnCollisionEnter(Collision colTarget) {
        if (colTarget.gameObject.tag == "Enemy" || colTarget.gameObject.tag == "Wall" || colTarget.gameObject.tag == "Player" || colTarget.gameObject.tag == "Bullet") {
            DestroyObject(gameObject);
        }
    }
}
