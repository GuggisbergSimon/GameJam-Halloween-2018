using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class SatelliteControllerParabole : MonoBehaviour
{
	[SerializeField] private float speed = 10;
	[SerializeField] private float amplitude = 5;
	[SerializeField] private float period = 5;
	public int damage = 10;
	private Rigidbody2D myRigidbody2D;

	void Start()
	{
		myRigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		float A = amplitude;
		float B = (2 * Mathf.PI)/period;
		myRigidbody2D.velocity = Vector2.up* A * Mathf.Cos(B * Time.time) + Vector2.left * speed;
	}
}