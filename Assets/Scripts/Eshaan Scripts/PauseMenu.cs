using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;


    public GameObject pauseScreen;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


    }
    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }

    public void menu()
    {
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }





}


