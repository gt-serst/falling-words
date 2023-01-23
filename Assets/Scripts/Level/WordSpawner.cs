using UnityEngine;

public class WordSpawner : MonoBehaviour
{
	public GameObject wordPrefab;
	public Transform wordCanvas;
	public int level;

	public void Awake ()
	{
		level = PlayerPrefs.GetInt("Sauv_Language"); //recup de la variable sauv dans les PlayerPrefs
	}

	public WordDisplay SpawnWord()
	{
		if(level == 1)
		{
			GameObject wordObj = Instantiate(wordPrefab, wordCanvas); //instance les clones du prefab Word
			WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
			return wordDisplay;
		}
		if(level == 2)
		{
			Vector3 randomPosition = new Vector3(-7f,Random.Range(-2.5f, 2.5f));
			GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
			WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
			return wordDisplay;
		}
		if(level == 3)
		{
			Vector3 randomPosition = new Vector3(-7f,Random.Range(-2.5f, 2.5f));
			GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
			WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
			return wordDisplay;
		}
		else
		{
			Vector3 randomPosition = new Vector3(-7f,Random.Range(-2.5f, 2.5f));
			GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
			WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
			return wordDisplay;
		}
	}
}

