using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : ProjectileBase
{
    public Movement movement;
    Stats statScript;
    Vector3 initialPos;
    Vector3 mousePos;
    float instprojhealth;
    
    
    // Start is called before the first frame update
    void Start()
    {
        statScript = GameObject.Find("Player").GetComponent<Stats>();
        instprojhealth = statScript.projHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
        if (instprojhealth <= 0)
        {
            DestroySelf();
        }
        
    }

   

    public void SetDefault(float damage, float lifeSpan, float speed)
    {
        damageValue = damage;
        moveSpeed = speed;

        //Initial setup to tell ability how to move
        initialPos = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Kill self after life span over
        Invoke("DestroySelf", lifeSpan);
        
    }

    void MoveProjectile()
    {
        Vector3 projDirection = (mousePos - initialPos);
        projDirection.z = 0f;

        transform.position += projDirection.normalized * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            instprojhealth -= 25;
        }
        if(collision.gameObject.tag == "minion")
        {
            instprojhealth -= 5;
        }
    }
}
