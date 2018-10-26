using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D backgroundCollider;
    private float backgroundHorizontalLength;
    private float backgroundRepositionPosition = -58.19968f;

    // Use this for initialization
    void Start()
    {
        //backgroundCollider prend le collider, backgroundHorizontalLength la taille
        backgroundCollider = GetComponent<BoxCollider2D>();
        backgroundHorizontalLength = backgroundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //check quand il doit bouger
        if (transform.position.x < backgroundRepositionPosition)
        {
            
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        //backgroundOffset a quelle distance bouger le background
        Vector2 backgroundOffset = new Vector2(backgroundHorizontalLength * 2.0f, 0);
        //applique la transformation
        transform.position = (Vector2)transform.position + backgroundOffset;
    }
}

