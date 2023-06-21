using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public Vector3 playerVelocity;

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
