using UnityEngine;
public class Joker : MonoBehaviour
{
    public bool jokerAvailable;    
    private Animator mAnimator;

    void Start()
    {
        jokerAvailable = false;
        mAnimator = GetComponent<Animator>();
    }


    void Update()
    {

        if(!PauseMenu.gameIsPaused && !GameManager.gameHasEnded)
        {
            if(GameObject.FindGameObjectsWithTag("Word").Length == 0)
            {
                mAnimator.SetTrigger("TrEnd");
                Time.timeScale = 1f;
            }

            if(jokerAvailable)
            {
                mAnimator.SetTrigger("TrStart");
            }

            if(jokerAvailable && Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 0f;
                jokerAvailable = false;
            }
        }     
    }
}

