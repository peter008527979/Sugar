using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cheak : MonoBehaviour
{
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~小試身手，有三個基本圖案~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~筆畫有沿著基本圖案畫，就換下一個圖案~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    public int cheak1;
    public int cheak2;
    public int cheak3;
    public GameObject collider1;
    public GameObject collider2;
    public GameObject collider3;

    public Animator anim;
    public AudioSource sound;
    public AudioClip impact;

    //要下一張嗎
    bool next;

    void Start()
    {
        cheak1 = 0;
        cheak2 = 0;
        cheak3 = 0;
        collider2.SetActive(false);
        collider3.SetActive(false);
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        next = true;
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && next == true)
        {
            anim.Play("smalltext");
            next = false;
        }
            
/*~~~~~~~~~~~~~~~~~~~~~~~~~~如果按右鍵清除筆畫，重新偵測完整度~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (Input.GetMouseButtonDown(1))
        {
            cheak1 = 0;
            cheak2 = 0;
            cheak3 = 0;
        }
/*~~~~~~~~~~~~~~~~~~~~~~~~~~小試身手，第一關~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (cheak1 >= 10 && Input.GetMouseButtonUp(0))
        {
            anim.Play("smalltext1_fin");
            collider1.SetActive(false);
            collider2.SetActive(true);
            sound.PlayOneShot(impact, 0.7f);

            cheak1 = 0;
        }
/*~~~~~~~~~~~~~~~~~~~~~~~~~~小試身手，第二關~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (cheak2 >= 9 && Input.GetMouseButtonUp(0))
        {
            anim.Play("smalltext2_fin");
            collider2.SetActive(false);
            collider3.SetActive(true);
            sound.PlayOneShot(impact, 0.7f);

            cheak2 = 0;
        }
/*~~~~~~~~~~~~~~~~~~~~~~~~~~小試身手，第三關~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (cheak3 >= 10 && Input.GetMouseButtonUp(0))
        {
            Debug.Log("Down!");
            anim.Play("smalltext3_fin");
            sound.PlayOneShot(impact, 0.7f);

            cheak3 = 0;
            
            StartCoroutine("WaitAndPrint");
        }
    }


/*~~~~~~~~~~~~~~~~~~~~~~~~~~最後一個基本圖案畫完，等待轉場動畫(1.3秒)播完，進下一個場景~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(1.3f);
        anim.Play("smalltext_finish");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Choice");
    }

}
