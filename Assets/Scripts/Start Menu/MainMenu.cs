using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1f;
    }

    public void PlayLevelOne()
    {
        SceneManager.LoadScene("Game");
    }
    public void PlayLevelTwo()
    {

    }
    public void PlayLevelThree()
    {

    }
    public void PlayLevelFour()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
