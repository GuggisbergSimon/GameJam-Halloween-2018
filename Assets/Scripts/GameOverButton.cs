using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
	private AudioSource audio;

	public void Start()
	{
		audio = GetComponent<AudioSource>();
	}

    public void YesButton()
    {
        //Load l'ancien niveau
	    audio.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void NoButton()
    {
        //Load le Menu
		audio.Play();
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
