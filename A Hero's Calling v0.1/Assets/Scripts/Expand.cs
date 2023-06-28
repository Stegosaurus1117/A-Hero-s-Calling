using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{
    public GameObject expander;
    private GameObject currentExpander;

    private Vector3 originalScale;

    private float expandTimer = 0f;
    private float timeToExpand = 0.5f;

    private bool isExpanding;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = expander.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isExpanding)
        {
            Expander();
                    }
        if (isExpanding)
        {
            currentExpander.transform.localScale += new Vector3(0.02f, 0.02f, 0);
            expandTimer += Time.deltaTime;
        }
        if(expandTimer >= timeToExpand)
        {
            StopExpansion();
        }
       
    }

    public void Expander()
    {
        currentExpander = Instantiate(expander, transform);
        isExpanding = true;
        
    }

    private void StopExpansion()
    {
        isExpanding = false;
        expandTimer = 0f;
        currentExpander.transform.localScale = originalScale;
        Destroy(currentExpander);
       
    }
}
