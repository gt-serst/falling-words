using UnityEngine;

[System.Serializable]
public class Word {
	public string word;
	private int typeIndex;
	WordDisplay display;

	public Word (string _word, WordDisplay _display)
	{
		word = _word;
		typeIndex = 0;

		display = _display;
		display.SetWord(word);
	}
	public char GetNextLetter()
	{
		return word[typeIndex];
	}
	public void TypeLetter()
	{
		typeIndex++;
		display.RemoveLetter(); //Remove the letter on screen
	}
	public void TypeWrongLetter()
	{
		display.ChangeLettersColorToRed();
	}
	public bool WordTyped()
	{
		bool wordTyped = (typeIndex >= word.Length); //bool check si l'indexe a été incrémenté jusqu'à la longueur du mot, true si c'est le cas
		if(wordTyped)
		{
			display.RemoveWord(); //Remove the word on screen
		}

		return wordTyped;
	}
}
