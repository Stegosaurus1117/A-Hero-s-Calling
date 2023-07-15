using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class AttackArea : MonoBehaviour
{
    public GameObject triggerObj;
    private bool flipswitch;
    
    // Start is called before the first frame update
    private int damage = 3;
    private Attack2 attack;
    

    private void Start()
    {
        attack = GetComponentInParent<Attack2>();
        
    }
    private void Update()
    {
        if (flipswitch)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Health healthScript = triggerObj.GetComponent<Health>();

                healthScript.Attack(EType.melee);
            }
        }
        if (!flipswitch)
        {
            triggerObj = null;

        }
    }
    
    

 
 

    private void OnTriggerEnter2D(Collider2D collider)
    {
        triggerObj = collider.gameObject;
        flipswitch = true;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        flipswitch = false;
        
    }

}
*/