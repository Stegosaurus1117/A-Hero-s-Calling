using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 3;
    private Attack2 attack;

    private void Start()
    {
        attack = GetComponentInParent<Attack2>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Health healthComp = collider.GetComponent<Health>();

        if (healthComp != null)
        {
            attack.AttackTriggerEvent(healthComp);
            attack.attacking = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
       // Debug.Log("STAY");
    }
}
