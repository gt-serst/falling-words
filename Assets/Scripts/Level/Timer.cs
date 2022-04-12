using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Timer : MonoBehaviour
{
    int time;
    private float timerInterval = 10f;
    float tick;
    public Joker joker;
    public int level;
    public void Awake ()
    {  
        level = PlayerPrefs.GetInt("Sauv_Language"); //recup de la variable sauv dans les PlayerPrefs
    }

    void Start()
    {
        tick = timerInterval;
    }
    void Update()
    {
        if(level == 1 || level == 2)
        {
            time = (int)Time.timeSinceLevelLoad;
            GetComponent<TMP_Text>().text = time.ToString();

            if(time == 90f)
            {
                GameManager.instance.Victory();
            }
            
        }

        if(level == 3 || level == 4)
        {
            time = (int)Time.timeSinceLevelLoad;
            GetComponent<TMP_Text>().text = time.ToString();

            if(time == tick && time != 90f)
            {
                tick = time + timerInterval;
                joker.jokerAvailable = true;
            }

            else if (time == 90f)
            {
                GameManager.instance.Victory();
            }
        }
    }
}


