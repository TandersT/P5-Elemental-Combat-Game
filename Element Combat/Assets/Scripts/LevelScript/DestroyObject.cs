using UnityEngine;

public class DestroyObject : MonoBehaviour {

    void OnCollisionEnter(Collision bullet) {
            DestroyObject(gameObject);
            Debug.Log("Bullet was destroyed");
    }
}
