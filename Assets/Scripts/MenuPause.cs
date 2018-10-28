using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {
    
    [SerializeField]private GameObject pauseCanvas;
    [SerializeField] private GameObject EventSystem;
    private AudioSource audio;
    

    public void ActivePause ()
    {
        
        Time.timeScale = 0f;
        audio = EventSystem.GetComponent<AudioSource>();
        audio.Pause();
        pauseCanvas.SetActive(true);
    }

    public void DesactivePause()
    {
        
        pauseCanvas.SetActive(false);
        audio = EventSystem.GetComponent<AudioSource>();
        audio.Play();
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
            togglePause();
        if (Input.GetButtonDown("Retry") || Input.GetButtonDown("Cancel"))
            Retry();
    }
    
    void togglePause()
    {
        if (Time.timeScale == 0f)
        {
            DesactivePause();
        }
        else
        {
            ActivePause();
        }
    }
}
