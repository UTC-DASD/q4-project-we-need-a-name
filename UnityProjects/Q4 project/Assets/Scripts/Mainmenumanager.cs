using System;
using System.ComponentModel;
using NUnit.Framework;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
public static bool isPaused;

    [SerializeField] GameObject pauseMenu;
public GameObject Container;
    // Update is called once per frame

    public void Pause()
    {
        Container.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
         Container.SetActive(false);
         Time.timeScale = 1f;}

    public void Quit()
    { Application.Quit();}
    
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneidx");
    }
    }

