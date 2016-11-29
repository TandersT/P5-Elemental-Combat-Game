using UnityEngine;
using System.Collections;

public class fire_minion_behaviour : MonoBehaviour {

	public Animator fire;

	// Use this for initialization
	void Start () {
		fire = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("4")) {
			fire.Play ("still",-1,0f);
		}
		if (Input.GetKeyDown ("5")) {
			fire.Play ("walk",-1,0f);
		}
		if (Input.GetKeyDown ("6")) {
			fire.Play ("attack",-1,0f);
		}
	}
}
