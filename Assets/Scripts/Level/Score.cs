using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static float scoreValue = 0;
    public TMP_Text score;

    void Start()
    {
        score = GetComponent<TMP_Text>();   
    }

    void Update()
    {
        if(System.Single.IsNaN( scoreValue ))
        {
            score.text = "Vous n'avez pas tapé de touche...";
        }
        else if(scoreValue < 0)
        {
            score.text = "Vous avez fait beaucoup d'erreurs...";
        }
        else
        {
            score.text = "Score: " + (int)scoreValue + " %";
        }
    }
}
