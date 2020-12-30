using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //存放音频的数组
    public AudioClip[] audios;
    AudioSource Music;

    public bool m_ToggleChange;

    void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);
        Music = GetComponent<AudioSource>();
        Music.clip = audios[0];
        Music.Play();

    }
    void Update()
    {
        //取場景名稱
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Start")
        {
            m_ToggleChange = true;
        }
        if (scene.name == "TryThis")
        {

        }

        if (scene.name == "Choice" && m_ToggleChange == true)
        {
            Music.clip = audios[1];
            Music.Play();
            m_ToggleChange = false;
        }
    }

}
