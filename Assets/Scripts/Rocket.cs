using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Enemy
{
    [SerializeField] private float speed = 10;
	[SerializeField] private float distanceMin = -3;
	private Transform targetTransform;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        targetTransform = GameObject.FindWithTag("Player").transform;
        if (transform.position.x > distanceMin)
        {
           
            //rotate to look at the player
            transform.LookAt(targetTransform.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self); //correcting the original rotation
        }

        //move towards the player
        if (Vector3.Distance(transform.position, targetTransform.position) > 1f)
        {
            //move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        } 
    }
}
