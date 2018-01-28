using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GUIManager : MonoBehaviour {


    public Text inGameScoreText;
    public Text scoreOverText;
    public Text hiScoreOverText;
    public Text TextTitle;
    public Text TextNo;
    public GameObject gameOverMenu;
    public Animator gameOverAnim;
    private AudioSource bgMusic;

	void Start ()
    {
        if (GameManager.singleton.isMusicOn == true)
        {
            AudioListener.volume = 1;
        }
        else if (GameManager.singleton.isMusicOn == false)
        {
            AudioListener.volume = 0;
        }
        bgMusic = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        if (GameManager.singleton != null)
        {
            TextNo.text = "ข้อที่. " +GameManager.singleton.Notext.ToString();
            inGameScoreText.text = "ตอบถูก " +GameManager.singleton.currentScore.ToString() +" ข้อ";
        }

        if (GameManager.singleton.isGameOver == true)
        {
            bgMusic.Stop();
            scoreOverText.text = "" + GameManager.singleton.currentScore;
            if(GameManager.singleton.currentMode == 1)
            {
                if(GameManager.singleton.hiScorea < GameManager.singleton.currentScore)
                {
                    GameManager.singleton.hiScorea = GameManager.singleton.currentScore;
                }
                hiScoreOverText.text = "" + GameManager.singleton.hiScorea;
                TextTitle.text = "ADDITION";
            }
            else if (GameManager.singleton.currentMode == 2)
            {
                if (GameManager.singleton.hiScoreb < GameManager.singleton.currentScore)
                {
                    GameManager.singleton.hiScoreb = GameManager.singleton.currentScore;
                }
                hiScoreOverText.text = "" + GameManager.singleton.hiScoreb;
                TextTitle.text = "SUBTRACTION";
            }
            else if (GameManager.singleton.currentMode == 3)
            {
                if (GameManager.singleton.hiScorec < GameManager.singleton.currentScore)
                {
                    GameManager.singleton.hiScorec = GameManager.singleton.currentScore;
                }
                hiScoreOverText.text = "" + GameManager.singleton.hiScorec;
                TextTitle.text = "MULTIPLICATION";
            }
            else if (GameManager.singleton.currentMode == 4)
            {
                if (GameManager.singleton.hiScored < GameManager.singleton.currentScore)
                {
                    GameManager.singleton.hiScored = GameManager.singleton.currentScore;
                }
                hiScoreOverText.text = "" + GameManager.singleton.hiScored;
                TextTitle.text = "DIVISION";
            }
            gameOverAnim.Play("SlideIn");
        }
	}

    public void RetryButton()
    {
        GameManager.singleton.currentScore = 0;
        GameManager.singleton.Notext = 0;
        SceneManager.LoadScene("GamePlay");
        GameManager.singleton.isGameOver = false;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.singleton.isGameOver = false;
    }

    public void BackButton()
    {
        SceneManager.LoadScene("ModeSelector");
    }


}
