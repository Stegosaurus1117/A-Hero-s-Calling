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
    public TextMeshProUGUI PUT;
    public TextMeshProUGUI DUT;
    public TextMeshProUGUI FRUT;
    
    //speed and health price text
    public TextMeshProUGUI SPT;
    public TextMeshProUGUI HPT;
    public TextMeshProUGUI PPT;
    public TextMeshProUGUI DPT;
    public TextMeshProUGUI FRPT;


    private int speedInt;
    private int healthInt;
    private int DisplaySpeedInt;
    private int penInt;
    private int DamageInt;
    private int fireRateInt;

    //speed and health upgrade price
    private int SUP;
    private int HUP;
    private int PUP;
    private int DUP;
    private int FRUP;

    
    
    // Start is called before the first frame update
    void Start()
    {
        

        healthInt = 0;
        speedInt = 10;
        SUP = 10;
        HUP = 20;
        PUP = 75;
        DUP = 50;
        FRUP = 50;
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplaySpeedInt = speedInt - 10;

        HUT.text = "Health: " + healthInt;
        HPT.text = "Price: " + HUP;
        SUT.text = "Speed: " + DisplaySpeedInt;
        SPT.text = "Price: " + SUP;
        PUT.text = "Penetration: " + penInt;
        PPT.text = "Price: " + PUP;
        DUT.text = "Damage: " + DamageInt;
        DPT.text = "Price: " + DUP;
        FRUT.text = "Firerate: " + fireRateInt;
        FRPT.text = "Price: " + FRUP;
        


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
            HUP += 20;
        }
    }

    public void upgradePen()
    {
        if(Score.score >= PUP)
        {
            penInt++;
            statScript.projHealth += 25;
            Score.score -= PUP;
            PUP += 50;
        }
    }    public void upgradeDamage()
    {
        if(Score.score >= DUP)
        {
            DamageInt++;
            statScript.projDmg += 6.25f;
            Score.score -= DUP;
            DUP += 50;
        }
    }
      public void upgradeFireRate()
    {
        if(Score.score >= FRUP)
        {
            fireRateInt++;
            if(statScript.fireRate <= 0.2f)
            {
                statScript.fireRate -= 0.05f;
            }
            Score.score -= FRUP;
            FRUP += 50;
        }
    }
      

}
