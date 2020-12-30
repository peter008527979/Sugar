using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour
{
    Animator anim;

    AudioSource audio;

    public Text FindPlayer;

    int contro;

    void Start()
    {
        //進入遊戲
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        contro = 0;
        FindPlayer.text = ("等待玩家...");
    }

/*~~~~~~~~~~~~~~~~~~~~~~~~~~按下S鍵，播放下一頁~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && contro == 1)
        {
            audio.Play();
            anim.Play("Start_FindPlayer");
            FindPlayer.text = ("玩家已就位！");
            contro = 0;
        }
        if (Input.GetKeyDown(KeyCode.S) && contro == 2)
        {
            audio.Play();
            anim.Play("Start_Infor1");
            contro = 0;
        }
        if (Input.GetKeyDown(KeyCode.S) && contro == 3)
        {
            audio.Play();
            anim.Play("Start_Infor2");
            contro = 0;
        }
        if (Input.GetKeyDown(KeyCode.S) && contro == 4)
        {
            audio.Play();
            anim.Play("Start_Infor3");
            contro = 0;
        }
        if (Input.GetKeyDown(KeyCode.S) && contro == 5)
        {
            audio.Play();
            anim.Play("Start_Loading");
            contro = 0;
        }
        if (Input.GetKeyDown(KeyCode.S) && contro == 6)
        {
            audio.Play();     
            contro = 0;
        }

    }

/*~~~~~~~~~~~~~~~~~~~~~~~~~~動畫播完，等待播放下一個動畫~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    void Start_2()
    {
        anim.Play("Start_2");
        contro = 1;
    }
    void Start_Hello()
    {
        anim.Play("Start_Hello");
    }
    void Contro1()
    {
        contro = 1;
    }
    void Contro2()
    {
        contro = 2;
    }
    void Contro3()
    {
        contro = 3;
    }
    void Contro4()
    {
        contro = 4;
    }
    void Contro5()
    {
        contro = 5;
    }
    void Contro6()
    {
        contro = 6;
    }
    void Start_Loading()
    {
        SceneManager.LoadScene(1);
    }

}
