using UnityEngine;
public class Joker : MonoBehaviour
{
    public bool jokerAvailable;    
    private Animator mAnimator;
    public int level;
    public void Awake ()
    {  
        level = PlayerPrefs.GetInt("Sauv_Language"); //recup de la variable sauv dans les PlayerPrefs
    }
    void Start()
    {
        jokerAvailable = false;
        mAnimator = GetComponent<Animator>();
    }

    void Update()
    {   
        if(level == 3 || level == 4)
        {
            if(!PauseMenu.gameIsPaused && !GameManager.gameHasEnded)
            {
                if(GameObject.FindGameObjectsWithTag("Word").Length == 0)
                {   
                    mAnimator.SetTrigger("TrEnd"); // end anim joker
                    Time.timeScale = 1f; // end joker
                }

                if(jokerAvailable)
                {
                    mAnimator.SetTrigger("TrStart"); // start anim joker
                }

                if(jokerAvailable && Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = 0f; // start joker
                    jokerAvailable = false;
                }
            }
        }

           
    }
}

