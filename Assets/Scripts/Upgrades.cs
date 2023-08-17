using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Upgrades : MonoBehaviour
{
    public Stats statScript;
    
    //speed and health upgrade text
    public TextMeshProUGUI SUT;
    public TextMeshProUGUI HUT;
    //speed and health price text
    public TextMeshProUGUI SPT;
    public TextMeshProUGUI HPT;

    private int speedInt;
    private int healthInt;
    private int DisplaySpeedInt;

    //speed and health upgrade price
    private int SUP;
    private int HUP;

    
    
    // Start is called before the first frame update
    void Start()
    {
        

        healthInt = 0;
        speedInt = 10;
        SUP = 10;
        HUP = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplaySpeedInt = speedInt - 10;

        HUT.text = "Health: " + healthInt;
        HPT.text = "Price: " + HUP;
        SUT.text = "Speed: " + DisplaySpeedInt;
        SPT.text = "Price: " + SUP;


        statScript.movementSpeed = speedInt / 5;

       
        

    }

    public void upgradeSpeed()
    {
        if(Score.score >= SUP)
        {
            speedInt++;
            Score.score -= SUP;
            SUP += 10;
        }
        

    }

    public void upgradeHealth()
    {
        if(Score.score >= HUP)
        {
            healthInt++;
            statScript.health += 10;
            Score.score -= HUP;
            HUP += 25;
        }

       
      
    }
}
