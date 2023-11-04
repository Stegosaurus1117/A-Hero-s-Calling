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
    //public float meleeDmg;
    public float fireRate;
    public float projDmg;
    public float projHealth;
    public float expandDmg;
    // Start is called before the first frame update
    public TextMeshProUGUI healthUI;


    private float flashTime = 0.1f;
    private Color flashColor = Color.white;
    private Color originalColor;
    private Material mat;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        originalColor = mat.color;
        
        if(Score.difficulty == 1)
        {
            projDmg += 35;
        }
        if(Score.difficulty == 2)
        {
            projDmg += 15;
        }
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
        Score.score = 0;
        //Score.experience += Score.addupexp;
        //Score.addupexp = 0;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "minion")
        {
            flash();
            //health -= 10;
            //Debug.Log(health);
        }
    }

    public void flash()
    {
        mat.color = flashColor;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        mat.color = originalColor;
    }
}
