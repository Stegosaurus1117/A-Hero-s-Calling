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
    public GameObject bossEnemy;
    public GameObject minionEnemy;
    public float spawnYLimit = 16f;
    public float spawnXLimit = 25f;


    float enemySpawnRate;
    float SpawnInt;
    float spawnTimer;

    float waveTimer;
    float waveDuration = 15f;

    int EnemyType;
    int EnemyNumber;
    int waveNumber;
    int maxBossSpawn = 5;
    public int BossNumber;

    bool hasSpawned = true;
    public bool bosswave = false;

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
        
        if (BossNumber == 0 && bosswave == true)
        {
            bosswave = false;
            waveNumber++;
        }

        waveTimer += Time.deltaTime;
        if(bosswave == false)
        {
            if (waveTimer > waveDuration)
            {
                waveTimer = 0;
                waveNumber++;
                CheckForBossWave();
                Debug.Log(waveNumber);

                if (enemySpawnRate > 0.1f)
                {
                    enemySpawnRate -= 0.1f;
                }
            }
        }
        

        if (hasSpawned && bosswave == false)
        {
            spawnTimer += Time.deltaTime;
        }
        

        if(spawnTimer > enemySpawnRate && bosswave == false)
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
        {
            EnemyType = Random.Range(1, EnemyNumber);

            Vector3[] spawns = new Vector3[4];

            Vector3 spawnLeftPos = new Vector3(-spawnXLimit, Random.Range(spawnYLimit, -spawnYLimit), transform.position.z);
            Vector3 spawnRightPos = new Vector3(spawnXLimit, Random.Range(spawnYLimit, -spawnYLimit), transform.position.z);
            Vector3 spawnUpPos = new Vector3(Random.Range(spawnXLimit, -spawnXLimit), spawnYLimit, transform.position.z);
            Vector3 spawnBottomPos = new Vector3(Random.Range(spawnXLimit, -spawnXLimit), -spawnYLimit, transform.position.z);

            spawns[0] = spawnLeftPos;
            spawns[1] = spawnRightPos;
            spawns[2] = spawnUpPos;
            spawns[3] = spawnBottomPos;

            switch (EnemyType)
            {
                case 1:
                    Instantiate(basicEnemy, spawns[Random.Range(0, spawns.Length)], transform.rotation);
                    SpawnInt = 1f;
                    break;
                case 2:
                    Instantiate(speedyEnemy, spawns[Random.Range(0, spawns.Length)], transform.rotation);
                    SpawnInt = 1.5f;
                    break;
                case 3:
                    Instantiate(toughEnemy, spawns[Random.Range(0, spawns.Length)], transform.rotation);
                    SpawnInt = 2f;
                    break;

            }
            //enemySpawnRate = SpawnInt * waveNumber;

            hasSpawned = true;

            //ChangeSpawn();
        }
        
    }

    void ChangeSpawn()
    {
        transform.position = new Vector3(Random.Range(-26, 28), 17.25f, 0);
        
    }

    void CheckForBossWave()
    {
        if (waveNumber % 5 == 0)
        {
            int wave5Fold = waveNumber / 5;

            if (waveNumber > 25) wave5Fold = maxBossSpawn;
            
            
            for(int i = 0; i < wave5Fold; i++)
            {

                Instantiate(bossEnemy, transform.position + new Vector3(0, 2, 0), transform.rotation);
                BossNumber++;
                ChangeSpawn();
               
            }
            bosswave = true;
           
        }
        

       
    }
}
