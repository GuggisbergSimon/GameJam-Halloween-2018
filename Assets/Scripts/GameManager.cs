using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Player player;
	[SerializeField] private float timeMax = 10;

	// Use this for initialization
	void Start () {
		
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
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			//play animation or whatever, wait for it to end and go to scene gameover
		}
	}

	void CheckVictory()
	{
		if (Time.timeSinceLevelLoad>timeMax)
		{
			//SceneManager.LoadScene(SceneManager.GetSceneByName("WinScene"));
			//play animation for end, wait for it to end and go to scene victory
		}
	}
}
