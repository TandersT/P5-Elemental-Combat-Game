using UnityEngine;
using System.Collections;

public class ElementTable : MonoBehaviour {
    [SerializeField]
	public static float elementWeight = 0.5f; // find a way to access this variable in unity inspector.
	private static float strong = 1.5f;
	private static float weak = 0.5f;
	private static float same = 1.0f;

	public static float lookUpElementMultiplier(string attackingElement, string defendingElement){
		strong = 1.0f + elementWeight;
		weak = 1.0f - elementWeight;
		uint row = 101;
		uint col = 101;
		float[,] elementTable = {{same, strong,weak},{weak,same,strong},{strong,weak,same,}};

		switch(attackingElement){
			case "fire": row = 0;
			break;
			case "earth": row = 1;
			break;
			case "water": row = 2;
			break;
			default : Debug.Log ("Row not valid:" + attackingElement);
			break;
		}

		switch(defendingElement){
			case "fire": col = 0;
			break;
			case "earth": col = 1;
			break;
			case "water": col = 2;
            break;
			default : Debug.Log ("Column not valid:" + defendingElement);
			break;
		}

		return elementTable [row, col]; 
	}
}
