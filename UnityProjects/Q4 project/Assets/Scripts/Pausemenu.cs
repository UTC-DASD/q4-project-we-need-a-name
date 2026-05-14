using System;
using System.ComponentModel;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Pausemenu : MonoBehaviour
{
public static bool isPaused;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] private GameObject buttonToShow; // Drag your hidden button here in Inspector

    // This method will be called by the Player Input component
    public void OnShowButtonPressed(InputAction.CallbackContext context)
    {
        // Only trigger when the button is first pressed down
        if (context.started)
        {
            buttonToShow.SetActive(true);
        }
    }
    public GameObject Container;
    // Update is called once per frame

    public void Pause()
    {
        Container.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        
    }
    public void Resume()
    {
         Container.SetActive(false);
         Time.timeScale = 1f;
            isPaused = false;
    }

    public void Quit()
    { Application.Quit();}
    
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("currentsceneidx");
    }
    }
    
