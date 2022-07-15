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
            score.text = "Tu n'as pas tapé de touche";
        }
        else if(scoreValue < 0)
        {
            score.text = "Tu as fait beaucoup de fautes, ce n'est pas grave, tu apprends de tes erreurs !";
        }
        else
        {
            score.text = "Score: " + (int)scoreValue + " %, bravo !";
        }
    }
}
