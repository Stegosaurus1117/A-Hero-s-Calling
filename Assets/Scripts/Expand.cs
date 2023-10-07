using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//move instantiating code to attack and expand, melee, proj, to their respective prefabs.

public class Expand : ProjectileBase
{
    public float expanderSize = 100f;


    private Vector3 originalScale;
    private float expandTimer = 0f;
    private float timeToExpand = 0.5f;
    private float ExpandCDTimer = 0f;
    private float ExpandCD = 5f;
    private bool startExpanding = false;
    private bool isExpanding;



    // Start is called before the first frame update
    void Start()
    {
       
        originalScale = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
            
            transform.localScale += new Vector3(0.3f, 0.3f, 0) * expanderSize * Time.deltaTime ;
            expandTimer += Time.deltaTime;

       /* if (startExpanding)
        {
            ExpandCDTimer += Time.deltaTime;
        }*/
        /*if(ExpandCDTimer >= ExpandCD)
        {
            startExpanding = false;
            ExpandCDTimer = 0f;
        }
        if(expandTimer >= timeToExpand)
        {
            StopExpansion();
        }*/
        
       
    }

    public void SetValue(float damage)
    {
        damageValue = damage;
    }

    public void Expander()
    {
        isExpanding = true;
    }

    public void ExpansionCD()
    {
        if(!startExpanding)
        {
            startExpanding = true;
        }
       
    }

    private void StopExpansion()
    {
        isExpanding = false;
        expandTimer = 0f;
        transform.localScale = originalScale;
       
    }

    public void SetDefault(float damage, float lifeSpan, float speed)
    {
        Invoke("DestroySelf", lifeSpan);
    }

}
