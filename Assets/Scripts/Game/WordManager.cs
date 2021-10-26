using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;

    public WordSpawner wordSpawner;
    private bool hasActiveWord;
    private Word activeWord;

    private float correctLetter = 0;
    private float incorrectLetter = 0;
    public int correctWord = 0;
    public AudioSource audioSource;
    public AudioClip wrongLetter;
    public AudioClip rightWord;
    public float position;

    void Update()
    {

        ScoreInGame.totalScore = correctWord;

        GameObject[] Target = GameObject.FindGameObjectsWithTag("Word");
        foreach(GameObject item  in Target)
        {
            position = item.transform.position.x;

            if(position > 7f)
            {
                Score.scoreValue = (1 - (incorrectLetter / correctLetter))*100;
                print(Score.scoreValue);
                GameManager.instance.Victory();
            }
        }
    }
    public void AddWord()
    {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
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
            //score bon nombre de mots-> rightword ++ puis display sur le menu score
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
}
