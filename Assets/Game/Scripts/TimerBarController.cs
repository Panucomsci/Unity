using UnityEngine;
using UnityEngine.UI;


public class TimerBarController : MonoBehaviour {

    public static TimerBarController instance;
    public Transform fillBar;
    public float timeLeft = 120.0f;
    public Text Timers;

    [HideInInspector]public float currentAmount;
    private float timeT;

	void Start ()
    {
        timeT = 0.0084f;
        GameManager.singleton.isGameOver = false;

        currentAmount = 1;
    }

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Update()
    {
        currentAmount  -= (timeT) * Time.deltaTime;
        fillBar.GetComponent<Image>().fillAmount = currentAmount;

        timeLeft -= Time.deltaTime;
        if(currentAmount <= 0)
        {
            Timers.text = "เหลือเวลา 0";
        }
        else
        {
            Timers.text = "เหลือเวลา " + timeLeft.ToString("N0") + " วินาที";
        }
        
        if (currentAmount <= 0)
        {
            GameManager.singleton.isGameOver = true;
        }
    }


}
