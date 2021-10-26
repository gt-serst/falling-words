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
        scoreInGame.text = totalScore + "mot(s) correct(s)"; 
    }
}
