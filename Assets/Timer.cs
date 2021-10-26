using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Timer : MonoBehaviour
{
    float time;
    public float timerInterval = 15f;
    float tick;
    public Joker joker;

    void Awake()
    {
        time = (int)Time.time;
        tick = timerInterval;

    }
    void Update()
    {
        GetComponent<TMP_Text>().text = time.ToString();
        time = (int)Time.time;

        if(time == tick)
        {
            tick = time + timerInterval;
            joker.jokerIsUsed = false;
        }
    }
}
