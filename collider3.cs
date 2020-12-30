using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collider3 : MonoBehaviour
{
    public Collider coll;

    void Start()
    {
        coll = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            coll.enabled = true;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        coll.enabled = false;
        GameObject.Find("Background").GetComponent<cheak>().cheak3 += 1;
    }


}
