using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour 
{

    GameObject player;

    public float enemySpeed;
    public float noChaseRadius;
    public float stopForceMultiplier;

    float distance;
    bool isDamaged;

    Vector3 directionOffset;
    Vector3 direction;
    Vector3 randomOffSet;

    Rigidbody2D rb;

    bool isattacking;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > noChaseRadius)
            {
                direction = player.transform.position - transform.position;
                Vector3 force = direction.normalized * Time.deltaTime * enemySpeed;
                rb.AddForce(force * 10);
            }
            else if(distance <= noChaseRadius && !isDamaged)
            {
                Vector3 velocity = rb.velocity;
                rb.AddForce(-velocity * stopForceMultiplier * Time.deltaTime);
            }
        }
     
        //RandomizeMovement();
    }

    public void Damaged()
    {
        isDamaged = true;

        Action Off = () => { isDamaged = false; };

        Invoke("Off", 1.5f);
    }
}
