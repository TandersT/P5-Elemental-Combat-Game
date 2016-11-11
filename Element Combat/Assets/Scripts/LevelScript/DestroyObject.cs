using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public string element;
    void OnCollisionEnter(Collision colTarget) {
            DestroyObject(gameObject);
            Debug.Log("Bullet was destroyed");
    }
}
