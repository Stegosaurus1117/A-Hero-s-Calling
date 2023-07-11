using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour 
{
    GameObject player;
    public float enemySpeed;

    float distance;
    Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > 1.5f)
        {
            direction = player.transform.position - transform.position;
            transform.position += direction.normalized * Time.deltaTime * enemySpeed;
        }

    }
}
