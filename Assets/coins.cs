using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{

    Rigidbody2D rb;

    public Stats statScript;

    Vector3 maxPosition;
    Vector3 minPosition;

    public float bobSpeed = 0.001f;
    float bobDirection = -1;
    float timeCounter = 0f;
    float timeUntilDestroy = 15;
    float aliveTime;
    Vector3 posBuffer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        statScript = GameObject.Find("Player").GetComponent<Stats>();
        maxPosition = transform.position += new Vector3(0, 1, 0);
        minPosition = transform.position -= new Vector3(0, -1, 0);

        posBuffer = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.isPlaying)
        {
            aliveTime += Time.deltaTime;
        }
        

        timeCounter += Time.deltaTime;
        float output = Mathf.Sin(timeCounter);

        posBuffer.y += output * bobSpeed;
        transform.position = posBuffer;

        Debug.Log(posBuffer.y);


        //rb.velocity = new Vector3(0, bobSpeed * bobDirection, 0);
        //transform.position = transform.position += new Vector3(0, bobSpeed * bobDirection, 0);

        /*if(transform.position.y >= maxPosition.y)
        {
            bobDirection = -1;
            
        }
        if(transform.position.y <= minPosition.y)
        {
            bobDirection = 1;
        }*/
        if(aliveTime > timeUntilDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Player")
        {
            statScript.health += 5;
            Destroy(gameObject);
        }
    }


}
