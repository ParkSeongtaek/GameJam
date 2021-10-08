using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance;

    private void Start()
    {
        Instance = this;
    }



    //class OBJ{  OnSollisionEnter ( Collision = Char)   // Gameover. -> Gameover  }

    public void Gameover()
    {
        Debug.Log("GAmeover");
    }

}
