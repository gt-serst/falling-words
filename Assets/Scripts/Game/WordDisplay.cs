using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WordDisplay : MonoBehaviour
{
    //We can create a start method here to have random fall speed
    
    public TMP_Text text;

    public float fallSpeed = 1f;

    public void SetWord (string word)
    {
        text.text = word;
    }
    public void RemoveLetter() // when we write word we remove it and when we write each letter that also get removed
    {
        text.text = text.text.Remove(0,1); //start at the first letter and one letter forward
        text.color = Color.green; 
    }
    public void RemoveWord() //when we have finish with the word
    {
        Destroy(gameObject);
    }
    public void Update()
    {
        transform.Translate(fallSpeed * Time.deltaTime, 0f, 0f); //move the word a tiny each frame

    }

}
