using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

     void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Toggle();
        }   
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;

            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource audio in audios)
            {
                audio.Pause(); 
            }
        }
        else
        {
            Time.timeScale = 1f;

            AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource audio in audios)
            {
                audio.Play();
            }
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene("Main"); 
    }

    public void Menu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");       
    }
}
