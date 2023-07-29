using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour 
{

    GameObject player;

    public float enemySpeed;
    public float chaseDistance;

    float distance;

    Vector3 directionOffset;
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
        if(player != null)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > chaseDistance && player != null)
            {
                direction = player.transform.position - transform.position + directionOffset;
                transform.position += direction.normalized * Time.deltaTime * enemySpeed + randomOffSet;
            }
        }

        RandomizeMovement();
    }

    
 
   void RandomizeMovement()
    {
        directionOffset = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);
    }
}
