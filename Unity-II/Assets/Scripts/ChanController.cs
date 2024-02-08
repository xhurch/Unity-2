using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanController : MonoBehaviour
{
    Animator chanim;
    Rigidbody rb;

    float inputH;
    float inputV;

    bool run;

    // Start is called before the first frame update
    void Start()
    {
        chanim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            chanim.Play("WAIT01");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            chanim.Play("WAIT02");
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            chanim.Play("WAIT03");
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            chanim.Play("WAIT04", -1, 0.15f);
        }
        if(Input.GetMouseButtonDown(0))
        {
            int n = Random.Range(0, 2);

            if(n == 0)
            {
                chanim.Play("DAMAGED00");
            }
            else
            {
                chanim.Play("DAMAGED01");
            }
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        chanim.SetFloat("inputH", inputH);
        chanim.SetFloat("inputV", inputV);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        rb.velocity = new Vector3(moveX, 0, moveZ);

    }
}
