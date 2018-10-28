using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {
    private Rigidbody2D rb2d;

    public float playerSpeed = 20;

    public int life = 100;
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        if ((Camera.main.WorldToScreenPoint(gameObject.transform.position).y > 600 && v > 0) ||
            (Camera.main.WorldToScreenPoint(gameObject.transform.position).y < 20 && v < 0))
        {
            v = 0;
        }

        Vector2 myVelocity = Vector2.up;
        myVelocity *= v * playerSpeed;
        
        rb2d.velocity = myVelocity;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            life -= 10;
	        if (life <= 0)
	        {
				Destroy(this);
				//launch gameManager GAMEOVER
	        }
            Destroy(collision.gameObject);
        }
    }
}