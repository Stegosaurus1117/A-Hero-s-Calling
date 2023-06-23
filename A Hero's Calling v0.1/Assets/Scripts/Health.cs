using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
