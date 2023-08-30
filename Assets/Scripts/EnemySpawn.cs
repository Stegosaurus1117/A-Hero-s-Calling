using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    GameObject player;

    public GameObject CurrentEnemy;
    public GameObject basicEnemy;
    public GameObject toughEnemy;
    public GameObject speedyEnemy;

    

    float enemySpawnRate;
    float SpawnInt;
    float spawnTimer;

    float waveTimer;
    float waveDuration = 5f;

    int EnemyType;
    int EnemyNumber;
    int waveNumber;

    bool hasSpawned = true;

    Vector3 randomSpawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        EnemyNumber = 2;
        waveNumber = 1;
        enemySpawnRate = 2;

        speedyEnemy.SetActive(false);
        toughEnemy.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        waveTimer += Time.deltaTime;
        if(waveTimer > waveDuration)
        {
            waveTimer = 0;
            waveNumber++;
            Debug.Log(waveNumber);

            if (enemySpawnRate > 0.1f)
            {
                enemySpawnRate -= 0.1f;
            }
        }

        if (hasSpawned)
        {
            spawnTimer += Time.deltaTime;
        }
        

        if(spawnTimer > enemySpawnRate)
        {
            spawnTimer = 0f;
            hasSpawned = false;
            SpawnEnemy();
            
        }
        if(waveNumber == 5)
        {
            speedyEnemy.SetActive(true);
            EnemyNumber = 3;
            
        }
        if (waveNumber == 10)
        {
            toughEnemy.SetActive(true);
            EnemyNumber = 4;
        }
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        EnemyType = Random.Range(1, EnemyNumber);
        
        switch (EnemyType)
        {
            case 1:
                Instantiate(basicEnemy, transform.position, transform.rotation);
                SpawnInt = 1f;
                break;
            case 2:
                Instantiate(speedyEnemy, transform.position, transform.rotation);
                SpawnInt = 1.5f;
                break;
            case 3:
                Instantiate(toughEnemy, transform.position, transform.rotation);
                SpawnInt = 2f;
                break;

        }
        //enemySpawnRate = SpawnInt * waveNumber;

        hasSpawned = true;

        ChangeSpawn();
    }

    void ChangeSpawn()
    {
        transform.position = new Vector3(Random.Range(-24, 24), 12, 0);
    }
}
