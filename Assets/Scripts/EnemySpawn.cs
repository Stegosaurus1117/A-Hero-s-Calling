using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    GameObject player;

    public GameObject basicEnemy;

    public float enemySpawnRate;
    
    float spawnTimer;

    bool hasSpawned = true;

    Vector3 randomSpawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSpawned)
        {
            spawnTimer += Time.deltaTime;
        }

        if(spawnTimer > enemySpawnRate)
        {
            spawnTimer = 0f;
            hasSpawned = false;
            SpawnEnemy();
            if(enemySpawnRate > 0.1f)
            {
                enemySpawnRate -= 0.1f;
            }
        }
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        Instantiate(basicEnemy, transform.position, transform.rotation);
        hasSpawned = true;

        ChangeSpawn();
    }

    void ChangeSpawn()
    {
        transform.position = new Vector3(Random.Range(-15, 15), 6, 0);
    }
}
