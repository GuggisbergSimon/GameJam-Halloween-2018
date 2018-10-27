using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeLeft : MonoBehaviour {

    
    
    private GameObject gameManager;
    private float TimeMax;
    private float TimeBeforeImpact;
    public Text impactText;

    // Update is called once per frame
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        TimeMax = gameManager.GetComponent<GameManager>().timeMax;
        TimeBeforeImpact = TimeMax - Time.timeSinceLevelLoad;

    }
    void Update () {
        TimeBeforeImpact = TimeMax - Time.timeSinceLevelLoad;
        if (TimeBeforeImpact > 0)
        {
            do
            {

                impactText.text = TimeBeforeImpact.ToString("F1");
                break;
            }
            while (TimeBeforeImpact > 0);
        }
        else
            impactText.text = 0.ToString("F1");
            

            
        
		
	}
}
