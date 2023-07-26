using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : ProjectileBase
{
    public Movement movement;
    Vector3 initialPos;
    Vector3 mousePos;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
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
}
