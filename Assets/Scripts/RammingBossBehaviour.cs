using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RammingBossBehaviour : BossBehaviour
{
    GameObject Player;

    public GameObject cross1;
    public GameObject cross2;

    Rigidbody2D rb;

    Vector3 rDirection;

    Color safeColour = Color.green;
    Color dangerColour = Color.red;
    Color prepareColour = Color.yellow;

    public float RamPower;

    float directionTimer;

    bool isRamming = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        cross1.GetComponent<MeshRenderer>().material.color = safeColour;
        cross2.GetComponent<MeshRenderer>().material.color = safeColour;
    }

    // Update is called once per frame
    void Update()
    {
        directionTimer += Time.deltaTime;

        if (directionTimer >= 5)
        {
            directionTimer = 0;
            SetRamDirection();
            Invoke("PrepareRam", 1);
            Invoke("DoRam", 2f);
            Invoke("StopRam", 3f);
        }

        if (CheckPlayerDistance() > 30f && isRamming)
        {
            StopRam();
        }
       
    }
    void DoRam()
    {
        rb.AddForce(rDirection.normalized * RamPower, ForceMode2D.Impulse);
        isRamming = true;
        cross1.GetComponent<MeshRenderer>().material.color = dangerColour;
        cross2.GetComponent<MeshRenderer>().material.color = dangerColour;
    }

    float CheckPlayerDistance()
    {
        return (Player.transform.position - transform.position).magnitude;
    }

    void StopRam()
    {
        rb.velocity = rb.velocity * 0;
        isRamming = false;
        cross1.GetComponent<MeshRenderer>().material.color = safeColour;
        cross2.GetComponent<MeshRenderer>().material.color = safeColour;

    }

    void PrepareRam()
    {
        cross1.GetComponent<MeshRenderer>().material.color = prepareColour;
        cross2.GetComponent<MeshRenderer>().material.color = prepareColour;
    }

    void SetRamDirection()
    {
        rDirection = Player.transform.position - transform.position;
    }

}
