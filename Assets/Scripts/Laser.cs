using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Enemy
{



    [SerializeField] private int timeSpawn;
    [SerializeField] private AudioSource shootWarningSound;
    float currCountdownValue;
    [SerializeField]private AudioSource shootSound;


    private Animator animator;
    

    public bool destroy = false;
    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
	    StartCoroutine(StartCooldown());
    }
	
	// Update is called once per frame
	void Update () {
	    if (destroy)
	    {
            Destroy(gameObject);
	    }
    }

   
    public IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(timeSpawn);
        shootWarningSound.Pause();
        shootSound.Play();
        animator.SetBool("Fire", true);
        

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && collider.gameObject.GetComponent<Player>().life>0)
        {
            collider.gameObject.GetComponent<Player>().Damage(damage);
        }
    }
}
