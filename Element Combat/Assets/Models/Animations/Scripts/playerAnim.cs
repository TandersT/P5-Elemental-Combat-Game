using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// detect if we're pressing a button
		if (Input.GetKeyDown("w")) {
			//-1 indicats where the animations are in the animator which is the base layer
			anim.Play ("walk", -1, 0f);
		} 

		if (Input.GetMouseButtonDown(0)) {
			anim.Play ("attack", -1, 0f);

}
}
}
