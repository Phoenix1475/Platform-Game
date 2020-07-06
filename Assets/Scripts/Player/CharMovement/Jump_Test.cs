using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class Jump_Test : MonoBehaviour
{

    Jump_Test playerBase;
    Rigidbody2D rigidbody2D;



    // Start is called before the first frame update
    void Start()
    {
        playerBase = gameObject.GetComponent<Jump_Test>();
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }



    void Awake()
    {

        //playerBase = gameObject.GetComponent<Player_Base>();
        //rigidbody2D = transform.GetComponent<Rigidbody2D>();

    }




    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            float jumpVelocity = 8f;
            rigidbody2D.velocity = Vector2.up * jumpVelocity;

            Debug.Log("Space was Pressed");

        }

    }
}
