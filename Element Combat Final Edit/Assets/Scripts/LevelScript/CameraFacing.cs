using UnityEngine;
using System.Collections;

public class CameraFacing : MonoBehaviour {
    public Camera m_Camera;
    Canvas enemyCanvas;

    void Awake() {
        m_Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        enemyCanvas = gameObject.GetComponent<Canvas>();
    }
    void Update() {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
        enemyCanvas.worldCamera = m_Camera;
    }
}