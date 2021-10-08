using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    //DB

    int maxScore =0;
    public void SetMaxScore(int score)
    {
        maxScore = score;
    }
    public int GetMaxScore()
    {
        return maxScore;
    }

    //Char state
    public bool inGame = true;
    public bool pause = false;
    public bool gameOver = false;




    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
        }
        maxScore = PlayerPrefs.GetInt("MaxScore",0);


    }
    public void Save()
    {
        PlayerPrefs.SetInt("MaxScore", maxScore);

    } 

}
