using UnityEngine;

public class WordTimer : MonoBehaviour
{
    //words spawn more and more faster 
    public WordManager wordManager;
    public float wordDelay;
    private float nextWordTime = 0f;
    public int level;
    public GameObject[] gameObjects;
    public void Awake ()
    {  
        level = PlayerPrefs.GetInt("Sauv_Language"); //recup de la variable sauv dans les PlayerPrefs
    }
    private void Update ()
    {        
        if(level == 1 || level == 2)
        {
            if(GameObject.FindGameObjectsWithTag("Word").Length == 0)
            {
                wordManager.AddWord();
            }
        }

        if(level == 3)
        {
            wordDelay = 4f;
            if(Time.time >= nextWordTime)
            {
                wordManager.AddWord();
                nextWordTime = Time.time + wordDelay;
            }
        }

        if(level == 4)
        {
            wordDelay = 2f;
            if(Time.time >= nextWordTime)
            {
                wordManager.AddWord();
                nextWordTime = Time.time + wordDelay;
            }

        }
    }
}
