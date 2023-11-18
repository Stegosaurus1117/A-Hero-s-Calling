using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    protected Health healthScript;
    protected EnemySpawn spawnScript;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        spawnScript = GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>();
        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthScript.health <= 0)
        {
            spawnScript.BossNumber -= 1; 
            Score.score += 500;
            Score.GameScore += 500;
            Destroy(gameObject);
        }
    }
}
