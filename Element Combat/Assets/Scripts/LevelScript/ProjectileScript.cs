using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    public string element;
    void OnCollisionEnter(Collision colTarget) {
        if (colTarget.gameObject.tag == "Enemy" || colTarget.gameObject.tag == "Wall") {
            DestroyObject(gameObject);
            Debug.Log("Bullet was destroyed");
        }
    }
}
