using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded;

    public static GameManager instance;
    public ScoreMenu scoreMenu;
    
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameManager dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        gameHasEnded = false;
    }

    public void Victory()
    {
        gameHasEnded = true;
        Time.timeScale = 0f;
        scoreMenu.Score();
    }    
}


