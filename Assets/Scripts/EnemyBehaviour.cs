using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour 
{
    GameObject player;
    public float enemySpeed;

    float distance;
    Vector3 direction;
    Vector3 randomOffSet;

    bool isattacking;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > 2f)
        {
            direction = player.transform.position - transform.position;
            transform.position += direction.normalized * Time.deltaTime * enemySpeed + randomOffSet;
        }
        else
        {
          
        }
    }

   void RandomizeMovement()
    {
        randomOffSet.x = Random.Range(-0.5f, 0.5f);
        randomOffSet.y = Random.Range(-0.5f, 0.5f);
        randomOffSet.z = 0;
    }
}
