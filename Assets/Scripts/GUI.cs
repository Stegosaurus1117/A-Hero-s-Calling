using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


public class GUI : MonoBehaviour
{
    private Canvas canvas;
    public TextMeshProUGUI text;
    public TextMeshProUGUI Scoretext;
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Score: " + Score.GameScore;
        text.text = "$:" + Score.score;
  
    }

}
