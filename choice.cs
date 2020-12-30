using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class choice : MonoBehaviour
{
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

    void CloseAn()
    {
        anim.enabled = false;
    }

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
            if (time_int == 0)
            {
                //time_UI.text = "!!";
                anim.Play("choiceFinishDraw");
                StopCoroutine("WaitAndPrint");
            }
        }

    }


    void PictrurSceen()
    {
        SceneManager.LoadScene(3);
    }



}
