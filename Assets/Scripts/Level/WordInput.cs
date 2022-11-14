using UnityEngine;

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;
    public PauseMenu pauseMenu;
    public Joker joker;
    public int level;

    public void Awake ()
    {
        level = PlayerPrefs.GetInt("Sauv_Language"); //recup de la variable sauv dans les PlayerPrefs
    }

    void Update()
    {

        foreach(char letter in Input.inputString)
        {
            if(!PauseMenu.gameIsPaused && !GameManager.gameHasEnded){
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Debug.Log("Mettre en pause");
                    pauseMenu.Pause();
                }
                else if(Input.GetKeyDown(KeyCode.Space) && (level == 3 || level == 4))
                {
                    joker.startJoker();
                }
                else
                {
                    wordManager.TypeLetter(letter);
                }
            }
            else if(PauseMenu.gameIsPaused && !GameManager.gameHasEnded)
            {
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    Debug.Log("Reprendre");
                    pauseMenu.Resume();
                }
            }
        }
    }
}
