using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Upgrades : MonoBehaviour
{
    public Stats statScript;

    public TextMeshProUGUI SUT;
    public TextMeshProUGUI HUT;

    private int speedInt;
    private int healthInt;
    private int DisplaySpeedInt;

    
    
    // Start is called before the first frame update
    void Start()
    {
        healthInt = 0;
        speedInt = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplaySpeedInt = speedInt - 5;

        HUT.text = "Health: " + healthInt;
        SUT.text = "Speed: " + DisplaySpeedInt;

        statScript.movementSpeed = speedInt / 5;
        

    }

    public void upgradeSpeed()
    {
        speedInt++;

    }

    public void upgradeHealth()
    {
        healthInt++;
        statScript.health += 10;
    }
}
