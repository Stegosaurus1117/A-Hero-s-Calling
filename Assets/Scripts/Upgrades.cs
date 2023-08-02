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

    
    
    // Start is called before the first frame update
    void Start()
    {
        speedInt = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        SUT.text = "Speed: " + speedInt;
    }

    public void upgradeSpeed()
    {
        speedInt++;
        
        
    }
}
