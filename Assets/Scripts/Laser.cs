using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private int time = 0;

    [SerializeField] private int timeSpawn;
    float currCountdownValue;

    private float countdownValue = 10;

    private Animator animator;

    private BoxCollider2D boxCollider;

    public bool destroy = false;
    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
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
        animator.SetBool("Fire", true);
        boxCollider.enabled = true;
        

    }
}
