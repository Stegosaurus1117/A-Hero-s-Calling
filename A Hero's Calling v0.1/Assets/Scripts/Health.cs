using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    private float timer = 0f;
    public float attackSpeed = 1f;

    private bool CanBeMelee = true;
    private bool beingAttacked = false;
    private bool CanBeShot = 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beingAttacked)
        {
            CanBeMelee = false;
            timer += Time.deltaTime;
            
        }
        if(timer >= attackSpeed)
        {
            beingAttacked = false;
            CanBeMelee = true;
            timer = 0f;

        }

        if (health <= 0)
        {
            KillThing();
        }

    }

    void KillThing()
    {
        Destroy(gameObject);
        Debug.Log("I am dead");
    }

    public void MeleeDmg(int dmg)
    {
        if (CanBeMelee)
        {
            beingAttacked = true;
            health -= dmg;
           

            Debug.Log(health);
        }
     
    }
    public void ProjDamage(int dmg)
    {
        if(CanBeShot)
        {
            beingShot = true;
            health -= dmg;
            Debug.Log(health);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Proj")
        {
            ProjDamage(5);
        }
    }
}
