using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {
    private AudioSource clickSound;

    void Start () {
        clickSound = GetComponent<AudioSource>();
    }

	void Update () {
		
	}

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
        clickSound.Play();
    }

    public void LetplayButton()
    {
        SceneManager.LoadScene("ModeSelector");
        clickSound.Play();
    }


}
