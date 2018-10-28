using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeLeft : MonoBehaviour {

    
    
    private GameObject gameManager;
    private float TimeMax;
    private float TimeBeforeImpact;
    public Text impactText;
    private GameObject player;

    // Update is called once per frame
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        TimeMax = gameManager.GetComponent<GameManager>().timeMax;
        player = GameObject.FindGameObjectWithTag("Player");
        TimeBeforeImpact = TimeMax - Time.timeSinceLevelLoad;

    }
    void Update () {
        TimeBeforeImpact = TimeMax - Time.timeSinceLevelLoad;
        if (TimeBeforeImpact > 0 && player.GetComponent<Player>().life > 0)
        {
                impactText.text = TimeBeforeImpact.ToString("F1");

        }
        else if (player.GetComponent<Player>().life > 0)
            impactText.text = 0.ToString("F1");
            

            
        
		
	}
}
