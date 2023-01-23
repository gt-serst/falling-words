using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreInGame : MonoBehaviour
{
	public static int totalScore;
	public TMP_Text scoreInGame;

	void Start()
	{
		scoreInGame = GetComponent<TMP_Text>();
	}

	void Update()
	{
		if(totalScore <= 1)
		{
			scoreInGame.text = totalScore + "";
		}
		else
		{
			scoreInGame.text = totalScore + "";
		}

	}
}
