using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {
    
    [SerializeField]private GameObject pauseCanvas;
    [SerializeField] private GameObject EventSystem;
    private AudioSource audioMenu;
    

    public void ActivePause ()
    {
        
        Time.timeScale = 0f;
        audioMenu = EventSystem.GetComponent<AudioSource>();
        audioMenu.Pause();
        pauseCanvas.SetActive(true);
    }

    public void DesactivePause()
    {
        
        pauseCanvas.SetActive(false);
        audioMenu = EventSystem.GetComponent<AudioSource>();
        audioMenu.Play();
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
