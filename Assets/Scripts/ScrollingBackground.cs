using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    private Rigidbody2D myRigidBody2D;
    public float scrollSpeed = -1.5f;

	// Use this for initialization
	void Start () {
        myRigidBody2D = GetComponent<Rigidbody2D> ();
        myRigidBody2D.velocity = new Vector2(scrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {

        //Stop Scrolling when Game Over
		
	}
}
