using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;


public class GameHandler : MonoBehaviour
{
    public Animator ui_R;
    public GameObject ui;
    void Awake()
    {

        AssetDatabase.Refresh(); //重新整理


        ui_R = ui.GetComponent<Animator>();
    }
    void Update()
    {

        AssetDatabase.Refresh(); //重新整理


        if (Input.GetKeyDown(KeyCode.Space))
        {
            PNG.TakeScreenshot_Static(1076 , 928);
            ui_R.Play("UI_RightHere");
        }
    }



    public Texture2D myImg; // 從外部拖拉自己喜歡的圖片進來
    public GameObject Image;

    void CreateImage()
    {
        myImg = AssetDatabase.LoadAssetAtPath("/Resources/CameraScreenshot2.png", typeof(Texture2D)) as Texture2D;
        Sprite s = Sprite.Create(myImg, new Rect(0, 0, myImg.width, myImg.height), Vector2.zero);
        Image = GameObject.Find("RightHere");
        Image.GetComponent<Image>().sprite = s;
    }

}
#endif
