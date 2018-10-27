using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public int life = 100;
	[SerializeField] private float moveForce = 365f;
	[SerializeField] private float maxSpeed = 10f;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		float v = Input.GetAxis("Vertical");
	    if ((gameObject.transform.position.y > 5 && v > 0) ||
	        (gameObject.transform.position.y < -5 && v < 0))
	    {
	        v = 0;
	    }
        if (v * rb2d.velocity.y < maxSpeed)
		{
			rb2d.AddForce(Vector2.up * v * moveForce);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Mathf.Abs(rb2d.velocity.y) > maxSpeed)
		{
			rb2d.velocity = new Vector2(0, Mathf.Sign(rb2d.velocity.y) * maxSpeed);
		}

		if ((gameObject.transform.position.y > 5 && rb2d.velocity.y > 0) ||
		    (gameObject.transform.position.y < -5 && rb2d.velocity.y < 0))
		{
			rb2d.velocity = new Vector2(0, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			life -= 10;
			Destroy(collision.gameObject);
		}
	}
}
