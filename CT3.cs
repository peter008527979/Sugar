using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CT3 : MonoBehaviour
{
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~     最後一關，更換拍照的背景     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

    public Renderer rendererA;
    public Renderer rendererB;
    public Renderer rendererC;

    public Texture[] texture;

    int a = 5;
    int b = 1;
    int c = 2;


    Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
        rendererA = GameObject.Find("P1").GetComponent<Renderer>();
        rendererB = GameObject.Find("P2").GetComponent<Renderer>();
        rendererC = GameObject.Find("P3").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
/*~~~~~~~~~~~~~~~~~~~~~~~~~~按下W鍵，上一個~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (Input.GetKeyDown(KeyCode.W))
        {
            a -= 1;
            if (a < 1)
                a = 5;
            b -= 1;
            if (b < 1)
                b = 5;
            c -= 1;
            if (c < 1)
                c = 5;

            animator.Play("3P_Left2");
            StartCoroutine(waittime(1f));
        }

/*~~~~~~~~~~~~~~~~~~~~~~~~~~按下S鍵，下一個~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (Input.GetKeyDown(KeyCode.S))
        {
            a += 1;
            if (a > 5)
                a = 1;
            b += 1;
            if (b > 5)
                b = 1;
            c += 1;
            if (c > 5)
                c = 1;

            animator.Play("3P_Right2");
            StartCoroutine(waittime(1f));
        }


/*~~~~~~~~~~~~~~~~~~~~~~~~~~變換背景的材質球的圖片~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        IEnumerator waittime(float mytime)
        { //宣告 IEnumerator
            yield return new WaitForSeconds(mytime); // 等待x秒
            rendererA.material.mainTexture = texture[a];
            rendererB.material.mainTexture = texture[b];
            rendererC.material.mainTexture = texture[c];
        }
    }
}
