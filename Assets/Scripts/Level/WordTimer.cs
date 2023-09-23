using UnityEngine;

public class WordTimer : MonoBehaviour
{
	//words spawn more and more faster
	public WordManager wordManager;
	//public float wordDelay;
	//private float nextWordTime = 0f;
	//public int level;
	public GameObject[] gameObjects;
/*
	public void Awake ()
	{
		level = PlayerPrefs.GetInt("Sauv_Language"); //recup de la variable sauv dans les PlayerPrefs
	}
*/
	private void Update ()
	{//no word delay because the user should entirely type the word for a new word occurence
		if(!PauseMenu.gameIsPaused && !GameManager.gameHasEnded)
		{
			if(GameObject.FindGameObjectsWithTag("Word").Length == 0)
			{
				wordManager.AddWord();
				Time.timeScale = 1f;
			}
		}
/* if condition to put a word delay between each word occurence
		if(level == 3)
		{
			wordDelay = 4f;
			if(Time.time >= nextWordTime)
			{
				wordManager.AddWord();
				nextWordTime = Time.time + wordDelay;
			}
		}

		if(level == 4)
		{
			wordDelay = 2f;
			if(Time.time >= nextWordTime)
			{
				wordManager.AddWord();
				nextWordTime = Time.time + wordDelay;
			}

		}
*/
	}
}