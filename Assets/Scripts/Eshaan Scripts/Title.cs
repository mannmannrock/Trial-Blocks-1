using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class Title : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseScreen;

    public GameObject title;
    public GameObject quitButton;
    public GameObject StartButton;


    private void Start()
    {
        title.SetActive(true);
        quitButton.SetActive(true);
        StartButton.SetActive(true);
    }

    public void startButton()
    {
        play();
    }

    public void play()
    {
        title.SetActive(false);
        quitButton.SetActive(false);
        StartButton.SetActive(false);
       
        SceneManager.LoadScene("CubeLevel");

    }

    public void Quit()
    {
        Application.Quit();
    }





}
