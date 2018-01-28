using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckButtonPress : MonoBehaviour {

    private Button thisButton;
    private int score;
    private int hiScore;
    public Image backgroundSprite;
    private AudioSource ansSound;

    [SerializeField]
    private AudioClip[] soundToPlay;
    
    void Start()
    {
        score = 0;
        ansSound = GetComponent<AudioSource>(); 
        thisButton = GetComponent<Button>();
        hiScore = GameManager.singleton.hiScore;
    }

    void Update()
    {
        score = GameManager.singleton.currentScore;
        if (hiScore < score)
        {
            hiScore = score;
            GameManager.singleton.hiScore = hiScore;
            GameManager.singleton.Save();
        }
    }

    public void checkTheTextofButton()
    {
        if (gameObject.CompareTag( MathsAndAnswerScript.instance.tagOfButton))
        {
            score++;
            GameManager.singleton.currentScore = score;
            GameManager.singleton.Notext += 1;
            ansSound.PlayOneShot(soundToPlay[0]);
        }
        else
        {
            TimerBarController.instance.currentAmount -= 0.0418f;
            TimerBarController.instance.timeLeft -= 5.0f;
            ansSound.PlayOneShot(soundToPlay[1]);
            GameManager.singleton.Notext += 1;
            StartCoroutine(ColorChange());
        }
        MathsAndAnswerScript.instance.MathsProblem();
    }

    IEnumerator ColorChange()
    {
        backgroundSprite.color = new Color32(221, 127, 127, 255);
        yield return new WaitForSeconds(0.05f);
        backgroundSprite.color = new Color32(255, 255, 255, 255);
    }

}
