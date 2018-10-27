using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour {

    public void YesButton()
    {
        //Load l'ancien niveau
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void NoButton()
    {
        //Load le Menu
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
