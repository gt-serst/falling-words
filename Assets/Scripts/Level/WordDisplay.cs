using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WordDisplay : MonoBehaviour
{
	//We can create a start method here to have random fall speed
	public TMP_Text	text;
	public int		level;

	public void Awake ()
	{
		level = PlayerPrefs.GetInt("Sauv_Language"); //recup de la variable sauv dans les PlayerPrefs
	}
	public void Start()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("UserWords");
		ReactWebController rwc = objs[0].GetComponent<ReactWebController>();
		if (rwc.userFont && rwc.userFontSize != 0)
		{
			text.font = rwc.userFont;
			text.fontSize = rwc.userFontSize;
		}
	}
	public void SetWord (string word)
	{
		if (word.Length > 10)
			text.fontSize -= 10;
		text.text = word;
	}
	public void RemoveLetter() // when we write word we remove it and when we write each letter that also get removed
	{
		text.text = text.text.Remove(0,1); //start at the first letter and one letter forward
		text.color = Color.green;
	}
	public void ChangeLettersColorToRed()
	{
		text.color = Color.red;
	}
	public void RemoveWord() //when we have finish with the word
	{
		Destroy(gameObject);
	}
	public void Update()
	{
		if(level == 1)
		{
			transform.Translate(0f, 0f, 0f);
		}
		if(level == 2)
		{
			transform.Translate((Time.deltaTime * 2f), 0f, 0f); //move the word a tiny each frame
		}
		if(level == 3)
		{
			transform.Translate((Time.deltaTime * 2f), 0f, 0f);
		}
		if(level == 4)
		{
			transform.Translate((Time.deltaTime * 3f), 0f, 0f);
		}
	}
}
