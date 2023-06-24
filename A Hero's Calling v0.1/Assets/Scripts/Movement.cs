using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public Vector3 playerVelocity;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
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

        playerVelocity = new Vector3(horizontal * movementSpeed, Vertical * movementSpeed, 0f);

        transform.position += playerVelocity;
    }
}
