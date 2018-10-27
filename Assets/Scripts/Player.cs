using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public int life = 100;
	private bool invincibility = false;
	private float timeInvicibility;
    
	[SerializeField] private float moveForce = 365f;
	[SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float maxTimeInvicibility = 100;
	[SerializeField] private CinemachineVirtualCamera vcam;
	[SerializeField] private CinemachineBasicMultiChannelPerlin noise;
    public bool animationEnd = false;
    private Animator playerAnimator;

    [SerializeField]private GameObject flame;
    // Use this for initialization
    void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	    playerAnimator = GetComponent<Animator>();
		vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
		noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
	    
	}

	void FixedUpdate()
	{
		float v = Input.GetAxis("Vertical");
	    if ((gameObject.transform.position.y > 4.3 && v > 0) ||
	        (gameObject.transform.position.y < -4.3 && v < 0))
	    {
	        v = 0;
	    }
	    else
	    {
	        flame.transform.rotation = Quaternion.Euler(0, 0, 45*v);
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
				Noise(0.0f,0.0f);
	            playerAnimator.SetBool("Invincibility", false);
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
			Noise(damage/10,0.5f);
            print(life);
            invincibility = true;
            timeInvicibility = maxTimeInvicibility;
        }

        if (life <= 0)
        {
            Noise(0.0f, 0.0f);
            rb2d.velocity = new Vector2(0, 0);
            gameObject.GetComponent<Player>().enabled = false;
            playerAnimator.SetBool("Mort", true);
        }
    }

	public void Noise(float amplitudeGain, float frequencyGain)
	{
		noise.m_AmplitudeGain = amplitudeGain;
		noise.m_FrequencyGain = frequencyGain;
	}

    public void animationEnded()
    {
        animationEnd = true;
    }
}
