using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ModeMenuManager : MonoBehaviour {

    private AudioSource clickSound;

    void Start()
    {
        clickSound = GetComponent<AudioSource>();
    }

    public void AdditionMode()
    {
        GameManager.singleton.currentScore = 0;
        GameManager.singleton.Notext = 0;
        GameManager.singleton.currentMode = 1;
        SceneManager.LoadScene("GamePlay");

        clickSound.Play();

    }

    public void SubtractionMode()
    {
        GameManager.singleton.currentMode = 2;
        GameManager.singleton.Notext = 0;
        SceneManager.LoadScene("GamePlay");
        clickSound.Play();
    }

    public void MultiplicationMode()
    {
        GameManager.singleton.currentScore = 0;
        GameManager.singleton.currentMode = 3;
        GameManager.singleton.Notext = 0;
        SceneManager.LoadScene("GamePlay");
        clickSound.Play();
    }

    public void DivisionMode()
    {
        GameManager.singleton.currentScore = 0;
        GameManager.singleton.currentMode = 4;
        SceneManager.LoadScene("GamePlay");
        clickSound.Play();
    }

    public void MixMode()
    {
        GameManager.singleton.currentScore = 0;
        GameManager.singleton.currentMode = 5;
        GameManager.singleton.Notext = 0;
        SceneManager.LoadScene("GamePlay");
        clickSound.Play();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
        clickSound.Play();
    }

}
