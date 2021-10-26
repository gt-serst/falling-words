using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded = false;

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

    public void Victory()
    {
        gameHasEnded = true;
        Time.timeScale = 0f;
        scoreMenu.Score();
    }
    
    //simplifier par une fonction victory lorsque un gameobject dépasse la ligne + affichage du score
    
}


