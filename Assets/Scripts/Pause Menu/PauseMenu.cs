using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject optionsWindow;
    
    void Start()
    {
        gameIsPaused = false;
    }
    void Update()
    {
        if (!GameManager.gameHasEnded && Input.GetKeyDown(KeyCode.Tab) && pauseMenuUI.activeSelf)
        {
            Resume();
        }
        else if (!GameManager.gameHasEnded && Input.GetKeyDown(KeyCode.Tab) && !gameIsPaused)
        {
            Pause();
        }
        else if (!GameManager.gameHasEnded && Input.GetKeyDown(KeyCode.Tab) && optionsWindow.activeSelf)
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
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        gameIsPaused = true; 
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

