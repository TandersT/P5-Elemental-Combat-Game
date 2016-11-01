using UnityEngine;

public class DestroyObject : MonoBehaviour {

    void OnCollisionEnter(Collision colTarget) {
        DestroyObject(gameObject);
        Debug.Log("Bullet was destroyed");
    }
}
