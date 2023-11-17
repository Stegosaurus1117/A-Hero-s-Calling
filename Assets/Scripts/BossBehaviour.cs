using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    EnemySpawn spawnScript;
    Health healthScript;

    GameObject minion;

    float spawnspeed = 0.2f;
    float spawnTimer;
    Vector3 posoffset;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnScript = GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>();
        minion = spawnScript.minionEnemy;
        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(healthScript.health <= 0)
        {
            spawnScript.BossNumber -= 1; 
            Score.score += 500;
            Score.GameScore += 500;
            Destroy(gameObject);
        }
        if(spawnTimer > spawnspeed)
        {
            spawnTimer = 0;
            Instantiate(minion, transform.position + posoffset, transform.rotation);
            ChangeOffset();
        }
        

    }
    void ChangeOffset()
    {
        posoffset = new Vector3(Random.Range(-1.8f, 1.1f), 1f, 0f);
    }
}
