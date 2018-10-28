using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
	private AudioSource audio;

	public void Start()
	{
		audio = GetComponent<AudioSource>();
	}

    public void PlayGame ()
	{
		audio.Play();
        //Load le prochain niveau
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
	    audio.Play();
		Application.Quit();
    }

    void Update()
    {
	    if (Input.GetButtonDown("Play"))
	    {
		    PlayGame();
	    }

	    if (Input.GetButtonDown("Cancel"))
        {
			QuitGame();
        }
    }
}
