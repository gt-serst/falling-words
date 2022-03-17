using UnityEngine;

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;

    public char[] alphabet = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

    void Update()
    {
        foreach(char letter in Input.inputString)
        {
            for(int i = 0; i < alphabet.Length; i++)
            {
                if(!PauseMenu.gameIsPaused && !GameManager.gameHasEnded && letter == alphabet[i])
                {
                    wordManager.TypeLetter(letter);
                }
            }
        }
        
        // if(!PauseMenu.gameIsPaused && !GameManager.gameHasEnded)
        //     {
        //         foreach(char letter in Input.inputString)
        //         {
        //             wordManager.TypeLetter(letter);
        //         }
        //     }
    }

}
