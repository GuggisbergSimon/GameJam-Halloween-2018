using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleColor : MonoBehaviour
{
	private SpriteRenderer m_SpriteRenderer;
	private float hue = 0;
	[SerializeField] private float speed = 0.01f;

	// Use this for initialization
	void Start ()
	{
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		hue += speed;
		hue %= 1;
		m_SpriteRenderer.color = Color.HSVToRGB(hue,1,1);
	}
}
