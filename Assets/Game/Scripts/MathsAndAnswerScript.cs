using UnityEngine;
using UnityEngine.UI;


public class MathsAndAnswerScript : MonoBehaviour {

    public static MathsAndAnswerScript instance;
    public enum MathsType
    {
        addition,
        subtraction,
        multiplication,
        division
    }
    public MathsType mathsType;
    private float a, b ;
    [HideInInspector] public float answer;
    private float locationOfAnswer;
    public GameObject[] ansButtons;
    public Image mathSymbolObject;
    public Sprite[] mathSymbols;
    public string tagOfButton;
    private int currentMode;
    public float timeForQuestion;
    [HideInInspector]public int score;
    public Text valueA , valueB;
    private float scoreMileStone;
    public float scoreMileStoneCount;


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

	void Start ()
    {
        tagOfButton = locationOfAnswer.ToString();
        scoreMileStone = scoreMileStoneCount;
        GameManager.singleton.timeForQuestion = timeForQuestion;

        if (GameManager.singleton != null)
        {
            currentMode = GameManager.singleton.currentMode;
        }

        CurrentMode();

        MathsProblem();
    }

    void CurrentMode()
    {
        if (currentMode == 1)
        {
            mathsType = MathsType.addition;

        }
        else if (currentMode == 2)
        {
            mathsType = MathsType.subtraction;
        }
        else if (currentMode == 3)
        {
            mathsType = MathsType.multiplication;
        }
        else if (currentMode == 4)
        {
            mathsType = MathsType.division;
        }
    }
	
	void Update ()
    {
        tagOfButton = locationOfAnswer.ToString();

        MileStoneProcess();
    }

    void MileStoneProcess()
    {
        if (scoreMileStone < GameManager.singleton.currentScore)
        {
            scoreMileStone += scoreMileStoneCount;

            timeForQuestion += 0.02f;

            if (timeForQuestion >= 0.2f)
            {
                timeForQuestion = 0.2f;
            }

        }
    }//set time bar

    public void MathsProblem()
    {
        switch (mathsType)
        {
            case (MathsType.addition):

                AdditionMethod();

                break;

            case (MathsType.subtraction):

                SubtractionMethod();

                break;

            case (MathsType.multiplication):

                MultiplicationMethod();

                break;

            case (MathsType.division):

                DivisionMethod();

                break;
        }
    }

    void AdditionMethod()
    {
        a = Random.Range(0, 21);
        b = Random.Range(0, 21);
        locationOfAnswer = Random.Range(0, ansButtons.Length);
        answer = a + b;
        valueA.text = "" + a;
        valueB.text = "" + b;
        mathSymbolObject.sprite = mathSymbols[0];

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {
                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1,99);
                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 99);
                }
            }
        }
     }// Addition

    void SubtractionMethod()
    {
        a = Random.Range(0, 21);
        b = Random.Range(0, 21);

        while (a <= b)
        {
            a = Random.Range(0, 21);
            b = Random.Range(0, 21);
        }

        locationOfAnswer = Random.Range(0, ansButtons.Length);

        answer = a - b;
        valueA.text = "" + a;
        valueB.text = "" + b;

        mathSymbolObject.sprite = mathSymbols[1];

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {
                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 41);
                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 41);
                }
            }
        }
    }//Subtraction

    void MultiplicationMethod()
    {
        a = Random.Range(1, 21);
        b = Random.Range(1, 21);

        locationOfAnswer = Random.Range(0, ansButtons.Length);

        answer = a * b;
        valueA.text = "" + a;
        valueB.text = "" + b;

        mathSymbolObject.sprite = mathSymbols[2];

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {
                if (a * b <= 100)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 101);
                }
                else if (a * b <= 200 & a * b > 100)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(101, 201);
                }
                else if (a * b <= 300 & a * b > 200)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(201, 301);
                }
                else if (a * b <= 400 & a * b > 300)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(301, 401);
                }

                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 401);
                }
            }
        }
    }//Multiplication

    void DivisionMethod()
    {
        a = Random.Range(1, 31);
        b = Random.Range(1, 31);

        while (a % b != 0)
        {
            a = Random.Range(1, 31);
            b = Random.Range(1, 31);
        }

        answer = a / b;
        locationOfAnswer = Random.Range(0, ansButtons.Length);
        valueA.text = "" + a;
        valueB.text = "" + b;

        mathSymbolObject.sprite = mathSymbols[3];

        for (int i = 0; i < ansButtons.Length; i++)
        {
            if (i == locationOfAnswer)
            {
                if (answer - (int)answer != 0)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = answer.ToString("F1");
                }
                else
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + answer;
                }
            }
            else
            {
                ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 31);

                while (ansButtons[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    ansButtons[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 31);
                }
            }
        }
    }//Division


}
