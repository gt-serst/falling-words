using UnityEngine;

public class WordTimer : MonoBehaviour
{
    //words spawn more and more faster 
    public WordManager wordManager;
    public float wordDelay = 12f;
    private float nextWordTime = 0f;
    private void Update ()
    {
       if(Time.time >= nextWordTime)
       {
           wordManager.AddWord();
           nextWordTime = Time.time + wordDelay;
       }
    }
}
