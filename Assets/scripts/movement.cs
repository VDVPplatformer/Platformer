using System.Collections;
using System;
using System.Timers;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    int dash_cd = 0;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float Axis = Input.GetAxis("Horizontal");
        if (Axis < 0&&dash_cd == 0)
        {
            anim.SetBool("running", true);
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(Axis * 10, rb.velocity.y);
            direction = -1;
        }
        else if (Axis > 0&& dash_cd==0)
        {
            anim.SetBool("running", true);
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(Axis * 10, rb.velocity.y);
            direction = 1;
        }
        else 
        {
            anim.SetBool("running", false);
        }

        if (Input.GetKeyDown("space")&&Math.Abs(rb.velocity.y)<0.001)
        {
            anim.SetBool("jumping", true);
            rb.velocity = new Vector3(rb.velocity.x, 22, 0);
        }
        if(rb.velocity.y < 0.001)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("fall", true);
        }
        if (Math.Abs(rb.velocity.y) < 0.001)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("fall", false);
        }

        if (Input.GetKeyDown("q")&&dash_cd==0)
        {
            anim.SetBool("dash", true);
            dash_cd = 200;
            Debug.Log(direction);
            rb.velocity = new Vector3(direction*20, rb.velocity.y, 0);

        }
        if(dash_cd!=0)
        {
            dash_cd--;
            Debug.Log(dash_cd);
        }
        else
        {
            anim.SetBool("dash", false);
        }
    }
}
