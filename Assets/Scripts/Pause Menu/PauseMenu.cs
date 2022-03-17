using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsWindow;
    
    void Update()
    {
        if (!GameManager.gameHasEnded && Input.GetKeyDown(KeyCode.Escape) && pauseMenuUI.activeSelf)
        {
            Resume();
        }
        else if (!GameManager.gameHasEnded && Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
        {
            Pause();
        }
        else if (!GameManager.gameHasEnded && Input.GetKeyDown(KeyCode.Escape) && optionsWindow.activeSelf)
        {
            Resume();
        }
        
    }
    public void Resume()
    {
        if(pauseMenuUI.activeSelf)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
        else
        {
            optionsWindow.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        gameIsPaused = true; 
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

