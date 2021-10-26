using UnityEngine;

public class WordTimer : MonoBehaviour
{
    //words spawn more and more faster 
    public WordManager wordManager;
    public float wordDelay = 4f;
    private float nextWordTime = 0f;
    private void Update ()
    {
       if(Time.time >= nextWordTime)
       {
           wordManager.AddWord();
           nextWordTime = Time.time + wordDelay;
           wordDelay *= 1f;//faster and faster rate, pas obliger !!! =1 donc pas de + en + vite
       }
    }
}
