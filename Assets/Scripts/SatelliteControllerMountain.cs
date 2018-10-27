using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class SatelliteControllerMountain : MonoBehaviour
{
	[SerializeField] private float speed = 10;
	[SerializeField] private int amplitude = 20;

	private int height = 0;
	private Rigidbody2D myRigidbody2D;

	void Start()
	{
		myRigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		//this code stinks
		Vector2 myVelocity = Vector2.up;
		if (height < amplitude*2)
		{
			height++;
			myVelocity *= speed;
		}
		else if (amplitude*2 <= height && height < 4*amplitude)
		{
			height++;
			myVelocity *= -speed;
		}
		else
		{
			height = 0;
		}

		myRigidbody2D.velocity = myVelocity + Vector2.left * speed;
	}
<<<<<<< Updated upstream
=======

	void OnTriggerEnter2D(Collider2D other)
	{
		//print("test");
		//Destroy(other.gameObject);
	}
>>>>>>> Stashed changes
}