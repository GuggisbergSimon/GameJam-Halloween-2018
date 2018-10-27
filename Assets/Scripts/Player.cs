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
    [SerializeField] private float maxTimeInvicibility = 100;
    private bool invincibility = false;
    private float timeInvicibility;

    private Animator playerAnimator;
    // Use this for initialization
    void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	    playerAnimator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		float v = Input.GetAxis("Vertical");
	    if ((gameObject.transform.position.y > 4.3 && v > 0) ||
	        (gameObject.transform.position.y < -4.3 && v < 0))
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

		if ((gameObject.transform.position.y > 4.25 && rb2d.velocity.y > 0) ||
		    (gameObject.transform.position.y < -4.25 && rb2d.velocity.y < 0))
		{
			rb2d.velocity = new Vector2(0, 0);
		}

	    if (invincibility)
	    {
            playerAnimator.SetBool("Invincibility", true);
	        timeInvicibility -= 1;
	        if (timeInvicibility <= 0)
	        {
	            invincibility = false;
	            playerAnimator.SetBool("Invincibility", false);
                //Debug.Log("Vincible");
            }
	    }
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
		    Damage(collision.gameObject.GetComponent<Enemy>().damage);
            
			Destroy(collision.gameObject);
		}
    }

    public void Damage(int damage)
    {
        if (!invincibility)
        {
            life -= damage;
            print(life);
            invincibility = true;
            timeInvicibility = maxTimeInvicibility;
        }

    }
}
