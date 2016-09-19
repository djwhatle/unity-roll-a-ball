using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Player object will be used for tracking info
	public GameObject player;

	// Offset will be set in the script
	// We will take current transform position delta between camera and player to determine offset
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Camera is moved into new position inline with camera object
		// Update is not the best place for this code
		// For follow-cameras, procedural animation, gathering last-known state, it's better to gather late-update
		transform.position = player.transform.position + offset;
	}
}
