﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PNG : MonoBehaviour
{
    static PNG instance;

    Camera myCamera;

    bool takeScreenshotOnNextFrame;


    void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }

    void OnPostRender()
    {
        if (takeScreenshotOnNextFrame)
        {
            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/Resources/CameraScreenshot2.png", byteArray);
            Debug.Log("成功截圖");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }


    void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame = true;
    }

    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width, height);
    }




    

}
