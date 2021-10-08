using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{

    float speed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TimerForDistroy()", 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    void TimerForDistroy()
    {
        Destroy(this.gameObject);
    }
}
