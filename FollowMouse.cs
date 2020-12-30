using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FollowMouse : MonoBehaviour
{
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~畫筆!~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

    public GameObject IP; //生成點。

    public GameObject[] Box = new GameObject[20]; //生成物件。
    
    //右鍵消除筆畫
    public GameObject Des;

    public string DesTarget;

    public int press = -1;

    //消除全部筆畫
    public GameObject[] DesAll;



    //開始作畫
    public static bool Candraw;
    
    
    //小試身手
    public SpriteRenderer spriteRenderer;
    Sprite sprite;

    //正式遊戲
    public SpriteRenderer ready;
    public SpriteRenderer choice;

    void Start()
    {
        Candraw = false;
    }


    void Update()
    {
/*~~~~~~~~~~~~~~~~~~~~~~~~~變數press計算筆畫的次數，依序從最後一個筆畫清除~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (press <= -1)
            press = -1;
        if (press >= 19)
            press = 19;
        DesTarget = press.ToString() + "(Clone)";
        
        Des = GameObject.Find(DesTarget);
/*~~~~~~~~~~~~~~~~~~~~~~~~~~跟隨滑鼠，按下左鍵生成預製物件~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));

        IP.transform.position = this.transform.position;

        if (Input.GetMouseButtonDown(0) && Candraw == true)
        {
            press += 1;
            Instantiate(Box[press], IP.transform.position, IP.transform.rotation);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(Des);
            press -= 1;
        }




        //取場景名稱
        Scene scene = SceneManager.GetActiveScene();

/*~~~~~~~~~~~~~~~~~~~~~~~~~小試身手~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (scene.name == "TryThis")
        {
            spriteRenderer = GameObject.Find("Background").GetComponent<SpriteRenderer>();

            if (spriteRenderer.sprite.name == "工作區域 113")
            {
                Candraw = true;
                DesAll[press] = GameObject.Find(DesTarget);
            }
            if (GameObject.Find("Background").GetComponent<cheak>().cheak1 >= 10 ||
                GameObject.Find("Background").GetComponent<cheak>().cheak2 >= 9)
            {
                if (Input.GetMouseButtonUp(0))
                    DesAllDraw();
            }
        }

/*~~~~~~~~~~~~~~~~~~~~~~~~~正式遊戲~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        if (scene.name == "Choice")
        {
            ready = GameObject.Find("ready").GetComponent<SpriteRenderer>();
            choice = GameObject.Find("Backround").GetComponent<SpriteRenderer>();
            DesAll[press] = GameObject.Find(DesTarget);
            if (ready.enabled == false)
                Candraw = true;

            if (choice.sprite.name == "工作區域 17")
            {
                Candraw = false;
                DesAllDraw2();
            }
            if (choice.sprite.name == "white")
            {
                Candraw = false;
            }

        }

    }

/*~~~~~~~~~~~~~~~~~~~~~~~~~清除所有畫筆~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    void DesAllDraw()
    {
        for (int i = 0; i < 20; i++)
            Destroy(DesAll[i], 1.333f);
    }

    void DesAllDraw2()
    {
        for (int i = 0; i < 20; i++)
            Destroy(DesAll[i]);
    }
}
