using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBoss : BossBehaviour
{
    GameObject minion;

    float spawnspeed = 0.2f;
    float spawnTimer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        spawnScript = GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>();
        minion = spawnScript.minionEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        //Spawns minions perdiodically
        if (spawnTimer > spawnspeed)
        {
            spawnTimer = 0;
            Instantiate(minion, transform.position, transform.rotation);
        }
    }
}
