using UnityEngine;
using System.Collections;

public class tree_minion_behaviour : MonoBehaviour {

	public Animator tree;

	// Use this for initialization
	void Start () {
		tree = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			tree.Play ("still",-1,0f);
		}
		if (Input.GetKeyDown ("2")) {
			tree.Play ("walk",-1,0f);
		}
		if (Input.GetKeyDown ("3")) {
			tree.Play ("attack",-1,0f);
		}
	}
}
