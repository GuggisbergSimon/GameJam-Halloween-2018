using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float playerSpeed = 20;

    public int life = 100;
    public float moveForce = 365f;
    public float maxSpeed = 10f;
    // Use this for initialization
    void Start ()
	{
	    rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    

	    float v = Input.GetAxis("Vertical");
	    
        if (v * rb2d.velocity.y < maxSpeed)
	        rb2d.AddForce(Vector2.up * v * moveForce);

        
	    if (Mathf.Abs(rb2d.velocity.y) > maxSpeed)
	        rb2d.velocity = new Vector2(0, Mathf.Sign(rb2d.velocity.y) * maxSpeed);
	    if ((Camera.main.WorldToScreenPoint(gameObject.transform.position).y > 600 && rb2d.velocity.y > 0) ||
	        (Camera.main.WorldToScreenPoint(gameObject.transform.position).y < 20 && rb2d.velocity.y < 0))
	    {
	        rb2d.velocity = new Vector2(0, 0);
        }
        //Debug.Log(rb2d.velocity);
	    Debug.Log(Camera.main.WorldToScreenPoint(gameObject.transform.position).y);

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
