using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceUI : MonoBehaviour
{
    public TextMeshProUGUI expText;
    public int AbilityReq;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        expText.text = "Experience: " + Score.experience;
        if(AbilityReq < Score.experience)
        {
            Destroy(gameObject);
        }
    }
}
