using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EType : int
{
    none = 0,
    melee,
    area,
    projectile

}


public class ProjectileBase : MonoBehaviour
{
    public EType attackType;
    public float damageValue;
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void DestroySelf()
    {
        Destroy(gameObject);
    }
}
