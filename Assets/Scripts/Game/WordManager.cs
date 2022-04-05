using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;

    public WordSpawner wordSpawner;
    public bool hasActiveWord;
    private Word activeWord;

    public float correctLetter = 0;
    public float incorrectLetter = 0;
    public int correctWord = 0;
    public AudioSource audioSource;
    public AudioClip wrongLetter;
    public AudioClip rightWord;
    public float position;

    void Update()
    {
        ScoreInGame.totalScore = correctWord;
        Score.scoreValue = (1 - (incorrectLetter / correctLetter))*100;
        
        GameObject[] Target = GameObject.FindGameObjectsWithTag("Word");
        
        foreach(GameObject item  in Target) //vérification de la position du GameObject et destruction si dépasse la ligne d'arrivée des mots
        {
            position = item.transform.position.x;

            if(position > 7f)
            {
                if(hasActiveWord == true)
                {
                    hasActiveWord = false;
                    words.Remove(activeWord);
                    Destroy(item);
                }
                else
                {
                    Destroy(item);
                    words.RemoveAt(0); // on enlève le premier mot de la liste Word car son GameObject vient d'être détruit
                }
            }
        }
    }
    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord()); // le mot Word se lie avec le vrai mot du jeu
        Debug.Log(word.word);
        words.Add(word);

    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            if (activeWord.GetNextLetter() == letter) //Check if the letter was next
            {
                activeWord.TypeLetter(); //Remove it from the word
                correctLetter++;
            }
            else 
            {
                audioSource.PlayOneShot(wrongLetter);
                incorrectLetter++;
            }
                

        }else
        {
            foreach(Word word in words)
            {
                if(word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    correctLetter++;                        
                }
                else
                {
                    audioSource.PlayOneShot(wrongLetter);
                    incorrectLetter++;
                }
                
                break;
            }
            
            
        
        }

        if (hasActiveWord && activeWord.WordTyped())
        {
            audioSource.PlayOneShot(rightWord);
            correctWord++;
            //mettre l'anim lampe
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}
