using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private float cooldownTime = 0.15f;
    private float currentTime;
    private bool canBeDamaged = true;
    private AudioSource ouchsoudn;
    public GameObject deathsound;

    EnemyBehaviour EB;


    // Start is called before the first frame update
    void Start()
    {
        EB = GetComponent<EnemyBehaviour>();
        ouchsoudn = GetComponent<AudioSource>();
        ouchsoudn.Stop();
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
            Instantiate(deathsound, transform.position, Quaternion.identity);
            Invoke("KillSelf", 0.05f);
            
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
        
        Score.score += 10;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProjectileBase objScript = collision.GetComponent<ProjectileBase>();
        
        if (objScript != null)
        {
            Attack(objScript);
            ouchsoudn.Play();
        }

        
    }
    public void Attack(ProjectileBase PB)
    {
        
        if (canBeDamaged)
        {
            currentTime = cooldownTime;
            health -= PB.damageValue;
            canBeDamaged = false;

            Vector3 playerPos = PB.gameObject.transform.position;
            Vector3 pushbackDirection = transform.position - playerPos;
            Vector3 pushbackForce = pushbackDirection.normalized * PB.knockbackValue * Time.deltaTime;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(pushbackForce, ForceMode2D.Impulse);

            EnemyBehaviour behaviour = GetComponent<EnemyBehaviour>();
            behaviour?.Damaged();
            EB.flash();
            
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
