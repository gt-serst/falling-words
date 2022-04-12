using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int level;
    
    public void Start()
    {
        Time.timeScale = 1f;
    }

    public void PlayLevelOne()
    {
        level = 1;
        SceneManager.LoadScene("Level");
        print(level);
        PlayerPrefs.SetInt("Sauv_Language",level);//Enregistre le int dans les playerPref
    }
    public void PlayLevelTwo()
    {
        level = 2;
        SceneManager.LoadScene("Level");
        PlayerPrefs.SetInt("Sauv_Language",level);//Enregistre le int dans les playerPref
    }
    public void PlayLevelThree()
    {
        level = 3;
        SceneManager.LoadScene("Level");
        PlayerPrefs.SetInt("Sauv_Language",level);//Enregistre le int dans les playerPref
    }
    public void PlayLevelFour()
    {
        level = 4;
        SceneManager.LoadScene("Level");
        PlayerPrefs.SetInt("Sauv_Language",level);//Enregistre le int dans les playerPref
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
