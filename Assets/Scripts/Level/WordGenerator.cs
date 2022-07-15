using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{

    private static string [] wordList = {"Chevalier", "Maison", "Arbre", "Fleur", "Meuble", "Travailler", "Jouer", "Feutre", "Fille", "Canon"};
    private static int compteur = 0;
    void Start(){

        GameObject[] objs = GameObject.FindGameObjectsWithTag("UserWords");
        ReactWebController rwc = objs[0].GetComponent<ReactWebController>();
        if(rwc.userWords.ToArray().Length!=0){
            wordList = rwc.userWords.ToArray();
        }

    }

    /* Fonction pour randomiser l'apparition des mots dans le jeu */

    // public static string GetRandomWord()
    // {
    //     int randomIndex = Random.Range(0, wordList.Length);
    //     string randomWord = wordList[randomIndex];

    //     return randomWord;
       
    // }

    /* Fonction pour suivre la séquence logique des mots dans la phrase lorsqu'il apparaisse */
    
    public static string GetNextWord()
    {
        string nextWord;

        if(compteur <= wordList.Length - 1)
        {
            nextWord = wordList[compteur];
            compteur++;
        }
        else
        {
            compteur = 0;
            nextWord = wordList[compteur];
            compteur++;
        }
        return nextWord;
    }
}
