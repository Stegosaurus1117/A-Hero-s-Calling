﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
     
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene(int nextScene)
    {
        Debug.Log("NEXT:: " + nextScene);
        SceneManager.LoadScene(nextScene);
        Time.timeScale = 1;
        Cursor.visible = true;
        Score.isPlaying = true;
        Score.PauseActive = false;
    }
}
