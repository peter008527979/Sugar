using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class choice : MonoBehaviour
{
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~       正式遊戲，選關卡       ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    Animator anim;

    public int time_int;

    public Text time_UI;

    public GameObject back;

    public SpriteRenderer spriteRenderer;
    Sprite sprite;


    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GameObject.Find("Backround").GetComponent<SpriteRenderer>();
        back.SetActive(false);
    }

    void Update()
    {

    }
/*~~~~~~~~~~~~~~~~~~~~~~~~~~使用Unity內建的Event Trigger時，關掉Animator元件，才不會影響按鈕變換圖片~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    void CloseAn()
    {
        anim.enabled = false;
    }
/*~~~~~~~~~~~~~~~~~~~~~~~~~~播放動畫時，順便設定倒數時間~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    void Tm30()
    {
        time_int = 30;
    }
    void Tm40()
    {
        time_int = 40;
    }
    void Tm50()
    {
        time_int = 50;
    }
/*~~~~~~~~~~~~~~~~~~~~~~~~~~播放動畫結束時，開始倒數時間~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    void timer()
    {            
        StartCoroutine("WaitAndPrint");
    }

    IEnumerator WaitAndPrint()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time_int -= 1;
            time_UI.text = time_int + "";
            
/*~~~~~~~~~~~~~~~~~~~~~~~~~~倒數時間 == 0，播放"時間到"動畫~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
            if (time_int == 0)
            {
                //time_UI.text = "!!";
                anim.Play("choiceFinishDraw");
                StopCoroutine("WaitAndPrint");
            }
        }

    }

/*~~~~~~~~~~~~~~~~~~~~~~~~~~倒數時間結束，進下一個場景~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    void PictrurSceen()
    {
        SceneManager.LoadScene(3);
    }



}
