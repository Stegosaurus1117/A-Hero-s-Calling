using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammingBossBehaviour : BossBehaviour
{
    GameObject Player;
    Rigidbody2D rb;

    Vector3 rDirection;

    public float RamPower;

    float directionTimer;

    bool isRamming = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        directionTimer += Time.deltaTime;

        if (directionTimer >= 5)
        {
            directionTimer = 0;
            DoRam();
            Invoke("StopRam", 2f);
        }

        if (CheckPlayerDistance() > 30f && isRamming)
        {
            StopRam();
        }
       
    }
    void DoRam()
    {
        rDirection = Player.transform.position - transform.position;
        rb.AddForce(rDirection.normalized * RamPower, ForceMode2D.Impulse);
        isRamming = true;
    }

    float CheckPlayerDistance()
    {
        return (Player.transform.position - transform.position).magnitude;
    }

    void StopRam()
    {
        rb.velocity = rb.velocity * 0;
        isRamming = false;
    }


    
    
}
