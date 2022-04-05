using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Timer : MonoBehaviour
{
    int time;
    public float timerInterval = 15f;
    float tick;
    public Joker joker;


    void Start()
    {
        tick = timerInterval;
    }
    void Update()
    {
        time = (int)Time.timeSinceLevelLoad;
        GetComponent<TMP_Text>().text = time.ToString();

        if(time == tick && time != 30f)
        {
            tick = time + timerInterval;
            joker.jokerAvailable = true;
        }

        else if (time == 30f)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        GameManager.instance.Victory();
    }
}

