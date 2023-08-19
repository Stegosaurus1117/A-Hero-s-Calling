using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : ProjectileBase
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
        MoveAttack();
    }

    public void SetDefault(float damage, float lifeSpan, float speed, float knockback)
    {
        damageValue = damage;
        moveSpeed = speed;
        knockbackValue = knockback;

        //Initial setup to tell ability how to move
        initialPos = transform.position;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Kill self after life span over
        Invoke("DestroySelf", lifeSpan);
    }

    void MoveAttack()
    {
        Vector3 attackDirection = (mousePos - initialPos);
        attackDirection.z = 0f;

        transform.position += attackDirection.normalized * moveSpeed * Time.deltaTime;
    }

}
