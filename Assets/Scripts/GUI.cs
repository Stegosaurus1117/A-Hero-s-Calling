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

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "$:" + Score.score;
    }

}
