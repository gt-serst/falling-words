using UnityEngine;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{

	// start react unity web gl
	[DllImport("__Internal")]
	private static extern void GameFinished (string text, string text_typed, int duration);
	// end react unity web gl


	public static bool gameHasEnded;

	public static GameManager instance;
	public ScoreMenu scoreMenu;

	public WordManager wordManager;// used to send informations to reactJS to store the restults in DB when the game is finished

	private void Awake()
	{
		if(instance != null)
		{
			Debug.LogWarning("Il y a plus d'une instance de GameManager dans la scène");
			return;
		}

		instance = this;
	}

	void Start()
	{
		gameHasEnded = false;
	}

	public void Victory()
	{
		string text = wordManager.GetText();
		string text_typed = wordManager.GetTextTyped();
		int duration = wordManager.GetDuration();
		// the game is finished
		#if UNITY_WEBGL == true && UNITY_EDITOR == false
			GameFinished(text, text_typed, duration);
		#endif
		gameHasEnded = true;
		Time.timeScale = 0f;
		scoreMenu.Score();
	}
}


