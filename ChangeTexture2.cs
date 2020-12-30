using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture2 : MonoBehaviour
{
    Renderer renderer;
    Animator animator;
    string anim;
    int i = 1;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.S))
        {
            i += 1;
            if (i > 5)
                i = 1;
            anim = "Change(" + i + ")";
            animator.Play(anim);



        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            i -= 1;
            if (i < 1)
                i = 5;
            anim = "Change(" + i + ")";
            animator.Play(anim);


        }

    }
}
