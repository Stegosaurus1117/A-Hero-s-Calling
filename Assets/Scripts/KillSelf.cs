using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour
{
    public int MoneyForKill;
    Health healthscript;
    // Start is called before the first frame update
    void Start()
    {
        healthscript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthscript.health <= 0)
        {
            Destroy(gameObject);
            Score.score += MoneyForKill;
        }
    }
}
