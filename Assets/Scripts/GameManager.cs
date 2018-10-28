using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] public float timeMax = 10;
	
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
		        Time.timeScale = 1f;
		        SceneManager.LoadScene("GameOver");
		    }
		}
	}

	void CheckVictory()
	{
		if (Time.timeSinceLevelLoad>timeMax && player.GetComponent<Player>().life > 0)
		{
            player.playerAnimator.SetBool("Fin", true);

		    player.audioMeteor.volume = 0.7f;
            if (player.end)
		    {
		        Time.timeScale = 1f;
		        SceneManager.LoadScene("WinScene");
		    }
		}
	}
}
