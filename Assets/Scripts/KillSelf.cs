using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour
{
    public GameObject coin;

    public int MoneyForKill;
    public int ScoreForKill;
    Health healthscript;
    // Start is called before the first frame update
    void Start()
    {
        healthscript = GetComponent<Health>();

        if (Score.difficulty == 1 && gameObject.tag == "Enemy")
        {
            MoneyForKill += 10;
            
        }
        if (Score.difficulty == 2 && gameObject.tag == "Enemy")
        {
            MoneyForKill += 5;
            ScoreForKill += 15;
        }
        if (Score.difficulty == 3 && gameObject.tag == "Enemy")
        {
            ScoreForKill += 25;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(healthscript.health <= 0)
        {
            if (Random.Range(0, 100) < 5)
            {
                Instantiate(coin, transform.position, transform.rotation);
            }
            Destroy(gameObject);
            Score.score += MoneyForKill;
            Score.GameScore += ScoreForKill;
        }
    }
}
