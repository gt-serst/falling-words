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
		if(level == 2 || level == 3 || level == 4)
		{
			if(!PauseMenu.gameIsPaused && !GameManager.gameHasEnded)
			{
				if(jokerAvailable)
				{
					mAnimator.SetTrigger("TrStart"); // start anim joker
				}
			}
		}
	}

	public void startJoker()
	{
		if(jokerAvailable)
		{
			Time.timeScale = 0f; // start joker
			jokerAvailable = false;
			mAnimator.SetTrigger("TrEnd"); // end anim joker
		}
	}
}

