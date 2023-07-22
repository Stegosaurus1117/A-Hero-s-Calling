using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //get damageValue component from projectile base script to do damage to enemy
    public float health = 100;
    
    /*
    private float meleeTimer = 0f;
    private float projTimer = 0f;
    private float expandTimer = 0f;
    public float attackSpeed = 0.2f;
    public float projCD = 3f;
    private float timeToExpand = 0.5f;

    private bool isExpanding = false;
    private bool beingAttacked = false;
    private bool beingShot = false;
    private bool CanBeShot = true;
    private bool CanBeMelee = true;
    private bool CanExpand = true;
    */

    private float cooldownTime = 0.2f;
    private float currentTime;
    private bool canBeDamaged = true;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
        /*
            if (beingAttacked)
            {
                CanBeMelee = false;
                meleeTimer += Time.deltaTime; 
            }
            if (beingShot)
            {
                projTimer += Time.deltaTime;
            }
            if (beingShot)
            {
                CanBeShot = false;
            
            }
            if (meleeTimer >= attackSpeed)
            {
                beingAttacked = false;
                CanBeMelee = true;
                meleeTimer = 0f;

            }
            if (projTimer > projCD)
            {
                beingShot = false;
                CanBeShot = true;
                projTimer = 0f;
            }
        */
        }

        IFrame();

        if (health <= 0)
        {
            KillSelf();
        }
    }

    void IFrame()
    {
        if (!canBeDamaged)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                canBeDamaged = true;
            }
        }
    }

    void KillSelf()
    {
        Destroy(gameObject);
        Debug.Log("I am dead");
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProjectileBase objScript = collision.GetComponent<ProjectileBase>();
        
        if (objScript != null)
        {
            Attack(objScript);
        }
    }
    public void Attack(ProjectileBase PB)
    {
        
        if (canBeDamaged)
        {
            currentTime = cooldownTime;
            health -= PB.damageValue;
            canBeDamaged = false;
            Debug.Log(health);
        }

        /*
        Action<float> DoStuff  = (float test) => {
            currentTime = cooldownTime;
            health -= test;
            Debug.Log(health);
        };
        */
        //Debug.Log(PB.damageValue);
    }
}
