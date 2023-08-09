using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Upgrades : MonoBehaviour
{
    public Stats statScript;

    public TextMeshProUGUI SUT;

    private int speedInt;
    private int DisplaySpeedInt;

    
    
    // Start is called before the first frame update
    void Start()
    {
        speedInt = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplaySpeedInt = speedInt - 5;

        SUT.text = "Speed: " + DisplaySpeedInt;
        statScript.movementSpeed = speedInt / 5;

    }

    public void upgradeSpeed()
    {
        speedInt++;

    }
}
