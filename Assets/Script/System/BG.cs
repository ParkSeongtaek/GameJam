using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public int Prefnum = 3;
    public GameObject[] BGPref = new GameObject[3];
    public float time = 2.5f;
    float timer = 0f;
    int idx = 0;
    private void Start()
    {
        
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (GameManager.Instance.inGame)
        {
            timer += Time.deltaTime;
            if (timer > time)
            {
                MakeBG();
                timer = 0f;
                if(idx< Prefnum)
                {
                    idx++;
                }
                else
                {
                    idx =0;

                }
            }
        }
    }

    void MakeBG()
    {

        Instantiate(BGPref[idx], this.gameObject.transform );

    }
}
