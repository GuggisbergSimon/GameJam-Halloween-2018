using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    Image healthBar;
    private float actualLife;
    private float maxLife;
    private GameObject player;

	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        maxLife = player.GetComponent<Player>().life;
        actualLife = player.GetComponent<Player>().life;

    }
	
	// Update is called once per frame
	void Update () {
        if(actualLife != player.GetComponent<Player>().life)
        {

            actualLife = player.GetComponent<Player>().life;
            if (actualLife < 0)
            {
                actualLife = 0;
            }

            float scaleSize = actualLife / maxLife;
            healthBar.transform.localScale = new Vector2(scaleSize, healthBar.transform.localScale.y);
        }

	    
	}
}
