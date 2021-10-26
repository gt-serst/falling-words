using UnityEngine;
public class Joker : MonoBehaviour
{
    public bool jokerIsUsed = false;    

    void Update()
    {
        if(!PauseMenu.gameIsPaused && !GameManager.gameHasEnded && Input.GetKeyDown(KeyCode.Space))
        {
            if(!jokerIsUsed)
            {
                Time.timeScale = 0f;
                jokerIsUsed = true;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}