using UnityEngine;

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;


    void Update()
    {   
        char[] clavier = {'a', 'b', 'c', 'd', 'e', 'f', 'g','h','i','j','k','l','m','n','o','p','q','r','s','t','w','u','v','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','W','U','V','X','Y','Z'};
        
        foreach(char letter in Input.inputString)
        {
            /* On vérifie que ce sont bien les touches principales du clavier qui sont prises en compte pour les erreurs
            de frappe */
            foreach(char x in clavier)
            {
                if(letter == x && !PauseMenu.gameIsPaused && !GameManager.gameHasEnded)
                {
                    wordManager.TypeLetter(letter);
                }
            }
        }
    }

}
