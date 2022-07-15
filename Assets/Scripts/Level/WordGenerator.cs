using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{

    private static string [] wordList = {"Aa", "Ab", "Ac", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
    
    void Start(){

        GameObject[] objs = GameObject.FindGameObjectsWithTag("UserWords");
        ReactWebController rwc = objs[0].GetComponent<ReactWebController>();
        if(rwc.userWords.ToArray().Length!=0){
            wordList = rwc.userWords.ToArray();
        }

    }

    
    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
       
    }
}
