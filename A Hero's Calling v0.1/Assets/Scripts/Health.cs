using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    private float timer = 0f;
    public float attackSpeed = 1f;

    private bool CanBeAttacked = true;
    private bool beingAttacked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beingAttacked)
        {
            CanBeAttacked = false;
            timer += Time.deltaTime;
        }
        if(timer >= attackSpeed)
        {
            beingAttacked = false;
            CanBeAttacked = true;
        }
    }

    void KillThing()
    {
        Destroy(gameObject);
        Debug.Log("I am dead");
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            KillThing();
        }

        Debug.Log(health);
    }

    void MakeTimer()
    {

    }
}
