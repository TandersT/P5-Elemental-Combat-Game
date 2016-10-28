using UnityEngine;
using System.Collections;

public class ElementTable : MonoBehaviour {
	[Range(0,1)]
	public float elementWeight;
	private float strong = 1.5f;
	private float weak = 0.5f;
	private float same = 1.0f;

	public float lookUpElementMultiplier(string attackingElement, string defendingElement){
		int col = 0, row = 0;
		strong = 1.0f + elementWeight;
		weak = 1.0f - elementWeight;
		float[,] elementTable = {{same, strong,weak},{weak,same,strong},{strong,weak,same,}};

		switch(attackingElement){
			case "fire": row = 0;
			break;
			case "earth": row = 1;
			break;
			case "water": row = 2;
			break;
			default : Debug.Log ("Row not specified.");
			break;
		}

		switch(defendingElement){
			case "fire": col = 0;
			break;
			case "earth": col = 1;
			break;
			case "water": col = 2;
			break;
			default : Debug.Log ("Column not specified.");
			break;
		}

		return elementTable [row, col]; 
	}

	void Update(){
		Debug.Log (lookUpElementMultiplier ("water", "earth"));
	}
}
