﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
	// Public variables can be changed from within the editor
	public float speed;
	public Text countText;
	public Text winText;

	// Private variables are for internal controller reference
	private Rigidbody rb;
	private int count;


	// Starts on the first frame of the object existence
	void Start()  
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

    // Update will run before every frame
    // Most game code will go here
    void Update()
    {

    }

    // FixedUpdate will run before Physics Calculations
    // This is where we put physics code
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
    }
		
	// Collider is the game object which we are colliding with
	void OnTriggerEnter(Collider other) {
		// We need to compare tags so that we don't disable the floor or walls as we collide
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
		// Destroy(other.gameObject);;
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "YOU WIN.";
		}
	}
		
} 