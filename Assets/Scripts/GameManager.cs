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
			//the destroy player is not working as intede, feel free to uncomment to see how
			//Destroy(player);
			//SceneManager.LoadScene(SceneManager.GetSceneByName("GameOver"));
			//play animation or whatever, wait for it to end and go to scene gameover
		}
	}

	void CheckVictory()
	{
		if (Time.timeSinceLevelLoad>timeMax)
		{
			//SceneManager.LoadScene(SceneManager.GetSceneByName("Victory"));
			//play animation for end, wait for it to end and go to scene victory
		}
	}
}
