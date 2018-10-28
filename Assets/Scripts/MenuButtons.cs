using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

    public void PlayGame ()
    {
        //Load le prochain niveau
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetButtonDown("Play"))
            PlayGame();

        if (Input.GetButtonDown("Cancel"))
        {
            QuitGame();
        }
    }
}
