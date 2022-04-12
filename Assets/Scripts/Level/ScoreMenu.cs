using UnityEngine;


public class ScoreMenu : MonoBehaviour
{
    public GameObject scoreMenuUI;
    public void Score()
    {
        scoreMenuUI.SetActive(true);
    }
}
