using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float cameraY = 200f;
	Vector3 cameraPosition;
    float previousLargestX = float.MinValue;
    float previousSmallestX = float.MaxValue;
    float previousLargestZ = float.MinValue;
    float previousSmallestZ = float.MaxValue;

	void FixedUpdate () {
		foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")){
			if(player.transform.position.x > previousLargestX){
				previousLargestX = player.transform.position.x;
			}else if(player.transform.position.x < previousSmallestX){
				previousSmallestX = player.transform.position.x;
			}

			if(player.transform.position.z > previousLargestZ){
				previousLargestZ = player.transform.position.z;
			}else if(player.transform.position.z < previousSmallestZ){
				previousSmallestZ = player.transform.position.z;
			}			

		}	
		cameraPosition = new Vector3((previousLargestX - previousSmallestX) / 2 + previousSmallestX, cameraY, (previousLargestZ - previousSmallestZ) / 2 + previousSmallestZ);
        gameObject.transform.position = cameraPosition;
    }
}
