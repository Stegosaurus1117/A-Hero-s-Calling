﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float movementSpeed;

    public float xLimit = 13.5f;
    public float yLimit = 5f;
    public Vector3 playerVelocity;
    private Vector3 mousePos;

    private Stats statScript;

    GameObject pausemenu;

    // Start is called before the first frame update
    void Start()
    {
        statScript = GetComponent<Stats>();
        rb = GetComponent<Rigidbody2D>();
        pausemenu = GameObject.Find("Pause Menu");
    }

    // Update is called once per frame
    void Update()
    {
        

        movementSpeed = statScript.movementSpeed;
        /*if(transform.position.x < -xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -yLimit)
        {
            transform.position = new Vector3(transform.position.x, yLimit, transform.position.z);
        }
        if (transform.position.y > yLimit)
        {
            transform.position = new Vector3(transform.position.x, -yLimit, transform.position.z);
        }*/
        



    }

    private void FixedUpdate()
    {
        mousePos = (Input.mousePosition);

        Vector3 mousePosScreen = Camera.main.ScreenToWorldPoint(mousePos);
        transform.LookAt(mousePosScreen, Vector3.forward);

        //Get the obj rotation and convert into usable form
        Quaternion currentRotation = transform.rotation;
        Vector3 eulerRotation = currentRotation.eulerAngles;

        //Constraint x and y axes, then invert the z-axis
        eulerRotation.x = 0f;
        eulerRotation.y = 0f;
        eulerRotation.z = eulerRotation.z * -1f;
        
        //Apply the modified rotation
        currentRotation = Quaternion.Euler(eulerRotation);
        transform.rotation = currentRotation;

        FindMovement();
    }

    void FindMovement()
    {
        float Vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        if(transform.position.x > -22.75)
        {
            rb.AddForce(new Vector3(100, 0, 0), ForceMode2D.Impulse);
        }
        playerVelocity = new Vector3(horizontal * movementSpeed, Vertical * movementSpeed, 0f);

        //transform.position += playerVelocity * Time.deltaTime;
        rb.velocity = playerVelocity.normalized * movementSpeed;
    }
}
