using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	public float cameraZ = 100.0f;
	Vector3 cameraPosition;
	
	void Start(){
	}
	
	void Update () {
		float previousLargestX = 0.0f;
		float previousSmallestX = float.MaxValue;
		float previousLargestY = 0.0f;
		float previousSmallestY = float.MaxValue;

		foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")){

			if(player.transform.position.x > previousLargestX){
				previousLargestX = player.transform.position.x;
			}else if(player.transform.position.x < previousSmallestX){
				previousSmallestX = player.transform.position.x;
			}

			if(player.transform.position.y > previousLargestY){
				previousLargestY = player.transform.position.y;
			}else if(player.transform.position.y < previousSmallestY){
				previousSmallestY = player.transform.position.y;
			}			

		}	

		cameraPosition = new Vector3((previousLargestX - previousSmallestX) / 2, (previousLargestY - previousSmallestY) / 2, cameraZ);
	}
}
