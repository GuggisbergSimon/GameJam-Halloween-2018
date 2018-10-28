using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
	private AudioSource audioMenu;

	public void Start()
	{
		audioMenu = GetComponent<AudioSource>();
	}

    public void PlayGame ()
	{
		audioMenu.Play();
        //Load le prochain niveau
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
	    audioMenu.Play();
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
