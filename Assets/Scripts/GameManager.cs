using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] public float timeMax = 10;
    float timer = 0.0f;
    // Use this for initialization
    void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckDefeat();
		CheckVictory();
	    
    }

	void CheckDefeat()
	{
		if (player.life <= 0)
		{
		    if (player.animationEnd)
		    {
		        SceneManager.LoadScene("GameOver");
		    }
		}
	}

	void CheckVictory()
	{
		if (Time.timeSinceLevelLoad>timeMax)
		{
			SceneManager.LoadScene("WinScene");
		}
	}
}
