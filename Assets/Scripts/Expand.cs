using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//move instantiating code to attack and expand, melee, proj, to their respective prefabs.

public class Expand : MonoBehaviour
{
    public float expanderSize = 50f;
    public GameObject expander;

    private GameObject currentExpander;
    private Vector3 originalScale;
    private float expandTimer = 0f;
    private float timeToExpand = 0.5f;
    private float ExpandCDTimer = 0f;
    private float ExpandCD = 5f;
    private bool startExpanding = false;
    private bool isExpanding;

    Stats StatScript;


    // Start is called before the first frame update
    void Start()
    {
        StatScript = GetComponent<Stats>();
        originalScale = expander.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !startExpanding)
        {
            Expander();
            ExpansionCD();
            
        }
        if (isExpanding)
        {
            currentExpander.transform.localScale += new Vector3(0.1f, 0.1f, 0) * expanderSize * Time.deltaTime ;
            expandTimer += Time.deltaTime;
        }
        if (startExpanding)
        {
            ExpandCDTimer += Time.deltaTime;
        }
        if(ExpandCDTimer >= ExpandCD)
        {
            startExpanding = false;
            ExpandCDTimer = 0f;
        }
        if(expandTimer >= timeToExpand)
        {
            StopExpansion();
        }
        
       
    }

    public void Expander()
    {
        currentExpander = Instantiate(expander, transform);
        currentExpander.GetComponent<ProjectileBase>().damageValue = StatScript.expandDmg;
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
        currentExpander.transform.localScale = originalScale;
        Destroy(currentExpander);
       
    }
}
