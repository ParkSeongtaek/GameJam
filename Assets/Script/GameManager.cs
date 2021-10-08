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
    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        
    }
}
