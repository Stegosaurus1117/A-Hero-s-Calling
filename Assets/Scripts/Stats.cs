using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public float health;
    public float defense;
    public float movementSpeed;
    public float meleeDmg;
    public float projDmg;
    public float expandDmg;
    // Start is called before the first frame update
    public TextMeshProUGUI healthUI;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.text = "Health: " + health;
        if (health <= 0)
        {
            KillSelf();
        }
    }
    
    void KillSelf()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= 10;
            Debug.Log(health);
        }
    }
}
