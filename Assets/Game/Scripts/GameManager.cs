using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;
    private GameData data;

    //data not to store on device
    public float timeForQuestion;
    public int currentScore;
    public int Notext;
    public bool isGameOver;
    public int currentMode;

    //data to store on device
    public int hiScore;
    public int hiScorea;
    public int hiScoreb;
    public int hiScorec;
    public int hiScored;
    public bool isMusicOn;
    public bool isGameStartedFirstTime;

    private AudioSource bgMusic;

    void Awake()
    {
        MakeSingleton();
        InitializeVariables();
    }

    void MakeSingleton()
    {
        if (singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        bgMusic = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Application.loadedLevelName == "GamePlay")
        {
            bgMusic.Stop();
        }
    }

    void InitializeVariables()
    {
        Load();

        if (data != null)
        {
            isGameStartedFirstTime = data.getIsGameStartedFirstTime();
        }
        else
        {
            isGameStartedFirstTime = true;
        }

        if (isGameStartedFirstTime)
        {
            isGameStartedFirstTime = false;
            hiScore = 0;
            isMusicOn = true;

            data = new GameData();
            data.setHiScore(hiScore);
            data.setIsMusicOn(isMusicOn);
            data.setIsGameStartedFirstTime(isGameStartedFirstTime);

            Save();
            Load();

        }
        else
        {
            isGameStartedFirstTime = data.getIsGameStartedFirstTime();
            isMusicOn = data.getIsMusicOn();
            hiScore = data.getHiScore();
        }
    }

    public void Save()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Create(Application.persistentDataPath + "/GameData.dat");
            if (data != null)
            {
                data.setHiScore(hiScore);
                data.setIsMusicOn(isMusicOn);
                data.setIsGameStartedFirstTime(isGameStartedFirstTime);
                bf.Serialize(file, data);
            }
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }

    public void Load()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
            data = (GameData)bf.Deserialize(file);
        }
        catch (Exception e)
        { }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }


}

[Serializable]
class GameData
{
    private int hiScore;
    private bool isMusicOn;
    private bool isGameStartedFirstTime;
    public void setIsGameStartedFirstTime(bool isGameStartedFirstTime)
    {
        this.isGameStartedFirstTime = isGameStartedFirstTime;
    }

    public bool getIsGameStartedFirstTime()
    {
        return isGameStartedFirstTime;
    }


    //HiScore
    public void setHiScore(int hiScore)
    {
        this.hiScore = hiScore;
    }

    public int getHiScore()
    {
        return hiScore;
    }

    //Music
    public void setIsMusicOn(bool isMusicOn)
    {
        this.isMusicOn = isMusicOn;
    }

    public bool getIsMusicOn()
    {
        return isMusicOn;
    }


}
