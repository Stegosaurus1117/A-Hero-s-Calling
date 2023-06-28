using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
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

                healthScript.MeleeDmg(3);
            }
        }
        if (!flipswitch)
        {
            triggerObj = null;

        }
    }

    

    public enum EType : int { 
        melee,
        area,
        range
    }

    public void Fire(EType _type)
    {
        int x = (int)EType.melee;

        switch (_type)
        {
            case EType.melee:
                break;
            case EType.area:
                break;
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
