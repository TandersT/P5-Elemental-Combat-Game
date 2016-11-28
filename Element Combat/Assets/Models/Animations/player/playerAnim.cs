using System.Collections;
using UnityEngine;
#pragma strict

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
		float walk = Input.GetAxis ("Vertical");
		anim.SetFloat ("walk", walk);

		//once the transition has begun, reset the bool
		if (Input.GetMouseButtonDown(0)) 
		{
			anim.Play ("attack", -1,0f);
		}
	}
}




//		// detect if we're pressing a button
//		if (Input.GetKeyDown("w")) {
//			//-1 indicats where the animations are in the animator which is the base layer
//			anim.Play ("walk", -1, 0f);
//		} 
//
//		if (Input.GetMouseButtonDown(0)) {
//			anim.Play ("attack", -1, 0f);

