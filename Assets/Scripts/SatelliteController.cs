using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class SatelliteController : MonoBehaviour
{
	[SerializeField] private float speed = 10;
	private Rigidbody2D myRigidbody2D;

	void Start()
	{
		myRigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		myRigidbody2D.velocity = Vector2.left*speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		print("test");
		Destroy(other.gameObject);
	}
}