using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;

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
        transform.position = new Vector2(transform.position.x + horizontal * movementSpeed, transform.position.y + Vertical * movementSpeed);
    }
}
