using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : MonoBehaviour
{
    private GameObject attackArea = default;
    public bool attacking = false;
    private bool canAttack = true;

    private float timeToAttack = 1f;
    private float timer = 0f;

    private Health enemyRef;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Timer::" + timer + "   " + "DeltaTime::" + Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer > timeToAttack)
            {
                timer = 0;
                canAttack = true;
                //attackArea.SetActive(false);
            }
        }
    }

    private void Attack()
    {
        if (enemyRef != null)
        {
            enemyRef.Damage(2);
        }

        attacking = true;
        canAttack = false;
    }

    public void AttackTriggerEvent(Health healthComp)
    {
        enemyRef = healthComp;
    }
    
}
