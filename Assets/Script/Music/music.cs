using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music : MonoBehaviour
{
    public Slider backVolume;
    public AudioSource audio;

    private float backVo1 = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        backVo1 = PlayerPrefs.GetFloat("backvo1", 1f);
        backVolume.value = backVo1;
        audio.volume = backVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        audio.volume = backVolume.value;

        backVo1 = backVolume.value;
        PlayerPrefs.SetFloat("backvo1", backVo1);
    }
}
