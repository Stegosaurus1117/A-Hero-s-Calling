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

    

    float enemySpawnRate;
    float SpawnInt;
    float spawnTimer;

    float waveTimer;
    float waveDuration = 1f;

    int EnemyType;
    int EnemyNumber;
    int waveNumber;
    int maxBossSpawn = 2;
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
