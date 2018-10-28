using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
	private AudioSource audioGameOver;

	public void Start()
	{
		audioGameOver = GetComponent<AudioSource>();
	}

    public void YesButton()
    {
        //Load l'ancien niveau
	    audioGameOver.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void NoButton()
    {
        //Load le Menu
		audioGameOver.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetButtonDown("Play") || Input.GetButtonDown("Retry"))
        {
            YesButton();
        }

        if (Input.GetButtonDown("Cancel"))
        {

            NoButton();
        }
    }
}
