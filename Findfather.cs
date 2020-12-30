using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Findfather : MonoBehaviour
{
    GameObject father_gameObject;   //宣告一個GameObject(用來放取得的子物件)。

    void Start()
    {   

        father_gameObject = GameObject.Find("father");

        // 宣告的物件 = father物件(利用Find尋找)。



        gameObject.transform.parent = father_gameObject.transform;

        // 自身物件的父母 = father物件。

    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            gameObject.transform.parent = null;
        } 
    }
}
