using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;

public class GameHandler : MonoBehaviour
{
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~  新增相機，對著要截圖的地方  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
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

        AssetDatabase.Refresh(); //重新整理，更新截圖的圖片

        if (Input.GetKeyDown(KeyCode.Space))
        {
@@ -34,11 +38,13 @@ void Update()


    public Texture2D myImg; // 從外部拖拉自己喜歡的圖片進來
    public GameObject Image;
    public GameObject Image; // 要顯示圖片的物件

    void CreateImage()
    {
/*~~~~~~~~~~~~~~~~~~~~~~~~~~找到圖片存的路徑~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        myImg = AssetDatabase.LoadAssetAtPath("/Resources/CameraScreenshot2.png", typeof(Texture2D)) as Texture2D;
/*~~~~~~~~~~~~~~~~~~~~~~~~~~圖片給材質~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        Sprite s = Sprite.Create(myImg, new Rect(0, 0, myImg.width, myImg.height), Vector2.zero);
        Image = GameObject.Find("RightHere");
        Image.GetComponent<Image>().sprite = s;
    }
}
#endif
