using UnityEngine;
using System.Collections;

public class minion_water_behaviour : MonoBehaviour {

	public Animator water;

	// Use this for initialization
	void Start () {
		water = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("7")) {
			water.Play ("still",-1,0f);
		}
		if (Input.GetKeyDown ("8")) {
			water.Play ("walk",-1,0f);
		}
		if (Input.GetKeyDown ("9")) {
			water.Play ("attack",-1,0f);
		}
	}
}
