using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeDifficulty : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDifficult(int difficulty)
    {
        Score.difficulty = difficulty;
        SceneManager.LoadScene(1);
        Debug.Log(Score.difficulty);

    }
}
