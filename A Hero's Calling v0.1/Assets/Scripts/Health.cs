using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100;

    private float meleeTimer = 0f;
    private float projTimer = 0f;
    public float attackSpeed = 1f;
    public float projCD = 3f;
    public float meleedmg = 5f;
    public float projdmg = 10f;
    public float expandDmg = 15f;
    private float expandTimer = 0f;
    private float timeToExpand = 0.5f;

    private bool isExpanding = false;
    private bool beingAttacked = false;
    private bool beingShot = false;
    private bool CanBeShot = true;
    private bool CanBeMelee = true;
    private bool CanExpand = true;
    
   

    public enum EType : int
    {
        melee,
        area,
        proj
    }
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
            meleeTimer += Time.deltaTime; 
        }
        if (beingShot)
        {
            projTimer += Time.deltaTime;
        }
        if(beingShot)
        {
            CanBeShot = false;
            
        }
        if(meleeTimer >= attackSpeed)
        {
            beingAttacked = false;
            CanBeMelee = true;
            meleeTimer = 0f;

        }
        if(projTimer > projCD)
        {
            beingShot = false;
            CanBeShot = true;
            projTimer = 0f;
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

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Proj")
        {
            Attack(EType.proj);
        }
        if(collision.gameObject.tag == "Expander")
        {
            Attack(EType.area);
        }
        if(collision.gameObject.tag == "Melee")
        {
            Attack(EType.melee);
        }
    }
    public void Attack(EType _type)
    {
        int x = (int)EType.melee;

        switch (_type)
        {
            case EType.melee:

                if (CanBeMelee)
                {
                    beingAttacked = true;
                    health -= meleedmg;
                    Debug.Log(health);
                }

                break;

            case EType.proj:

                if (CanBeShot)
                {
                    beingShot = true;
                    health -= projdmg;
                    Debug.Log(health);
                }

                break;

            case EType.area:
                if (CanExpand)
                {
                    isExpanding = true;
                    health -= expandDmg;
                    Debug.Log(health);
                }

                break;
        }
    }
}
