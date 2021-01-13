using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentScore;
    public int highScore;
    public float moneyEarned;
    public float currentMoney;

    public bool isGameOver;

    public GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            instance = GetComponent<GameManager>();
            //SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        SetScore();
        SetHighScore();
        MoneyEarned();
        GUIManager.instance.GameOver();
    }

    void SetScore()
    {
        currentScore = (int)(player.transform.position.y * 1.25f);
    }

    void SetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        if (currentScore > highScore)
        {
            //currentScore = PlayerPrefs.GetInt("HighScore");
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

    }

    void MoneyEarned()
    {

        moneyEarned = currentScore + currentScore / 2;
        //currentMoney += moneyEarned;
    }

    public float CurrentMoney()
    {
        currentMoney += moneyEarned;

        return currentMoney;
    }

    public int GetHeightOfPlayer()
    {
        return (int)player.transform.position.y;
    }
        

}
