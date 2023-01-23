using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WordManager : MonoBehaviour
{
	public List<Word> words;
	public WordSpawner wordSpawner;
	public SwitchColor switchColor;
	public bool hasActiveWord;
	public Word activeWord;
	public float correctLetter = 0;
	public float incorrectLetter = 0;
	public int correctWord = 0;
	public AudioSource audioSource;
	public AudioClip wrongLetter;
	public AudioClip rightWord;
	public float position;

	// ------ start variables to send to reactJS ------
	// start variables we are tracking to send to ReactJS when the game is finished. Doing so, we can store the results in our data base.
	private DateTime startingTime;
	private string text=""; // text that the user should have typed
	private string text_typed=""; // the text that the user has actually typed
	private bool is_letter_false=false; // We do not send that to ReactJS, but it is useful to store only once when an error is made on a letter. (if the user typed wrongly once the error, we only count it once)
	// ------ end variables to send to reactJS ------


	void Start(){
		startingTime = DateTime.Now;
	}


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
				if(hasActiveWord || is_letter_false){
					is_letter_false =false;
					// we have to add a space to mention a new word start when the word that the user was starting is deleted because out of zone
					// text = text + " " ;
					// text_typed = text_typed + " ";
				}
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
		//string word_text;
		Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord()); // le mot Word se lie avec le vrai mot du jeu
		words.Add(word);
	}

	public void TypeLetter(char letter)
	{
		if (hasActiveWord)
		{
			char correct_letter = activeWord.GetNextLetter();
			if (correct_letter == letter) //Check if the letter was next
			{
				activeWord.TypeLetter(); //Remove it from the word
				correctLetter++;

				if(!is_letter_false){// the user typed correctly the letter on the first try
					text = text + correct_letter; // word.GetNextLetter() was the correct letter to write
					text_typed = text_typed  + letter; // letter is the correct letter that has been typed
				}else{// the user typed correctly the letter after typing it wrongly once or more
					is_letter_false=false;
				}
			}
			else
			{
				audioSource.PlayOneShot(wrongLetter);
				if(!is_letter_false){
					activeWord.TypeWrongLetter();
					incorrectLetter++;
					is_letter_false = true;
					text = text + correct_letter; // word.GetNextLetter() was the correct letter to write
					text_typed = text_typed  + letter; // letter is the false letter that has been typed
				}else{
					// do nothing the first error has already be stored
				}
			}
		}else
		{
			foreach(Word word in words)
			{
				char correct_letter = word.GetNextLetter();
				if(correct_letter == letter)
				{
					activeWord = word;
					hasActiveWord = true;
					word.TypeLetter();
					correctLetter++;
					if(!is_letter_false){// the user typed correctly the letter on the first try
						 // between each word, we add a space to improve the readability (but not for the first word)
						if(text.Length!=0){
							text = text + " " +correct_letter;// correct_letter was the letter to type
							text_typed = text_typed + " "+letter;// letter was the letter to type and it was correctly typed
						}  else{
							text = text  +correct_letter;// correct_letter was the letter to type
							text_typed = text_typed +letter;// letter was the letter to type and it was correctly typed
						}


					}   else{// the user typed correctly the letter after typing it wrongly once or more
						is_letter_false=false;
					}
				}
				else
				{
					audioSource.PlayOneShot(wrongLetter);

					if(!is_letter_false){
						// the first time that is write wrongly the letter (of the new word in this case)
						word.TypeWrongLetter();
						incorrectLetter++;
						if(text.Length!=0){
							text = text +" "+ correct_letter; // correct_letter was the correct letter to write
							text_typed = text_typed  +" "+ letter; // letter is the false letter that has been typed
						}else{// if it's the first word, don't add the space
							text = text + correct_letter; // correct_letter was the correct letter to write
							text_typed = text_typed  + letter; // letter is the false letter that has been typed
						}
						is_letter_false=true;
					}
					else{
						// do nothing because the error has already been stored
					}
				}
				break;
			}
		}
		if (hasActiveWord && activeWord.WordTyped())
		{
			switchColor.SwitchOn();
			audioSource.PlayOneShot(rightWord);
			correctWord++;
			hasActiveWord = false;
			words.Remove(activeWord);
			switchColor.SwitchOff();
		}
	}

	/* 3 methods to send results to GameManager when the game is finished, the results will be sent to ReactJS after that*/
	public string GetText(){
		return text;
	}

	public string GetTextTyped(){
		return text_typed;

	}

	public int GetDuration(){
		return (int)(((DateTime.Now-startingTime).TotalSeconds));

	}
}
