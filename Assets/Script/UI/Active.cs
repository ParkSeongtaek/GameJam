using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    public GameObject Obj;
    
    public void ActiveFalse()
    {
        Obj.SetActive(false);
    }
    public void ActiveTrue()
    {
        Obj.SetActive(true);
    }
}
