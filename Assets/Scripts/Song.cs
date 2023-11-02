using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
    public AudioSource song;
    private float songTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        song.Play();
    }

    // Update is called once per frame
    void Update()
    {
        songTimer += Time.deltaTime;
        if(songTimer > 138f)
        {
            RestartSong();
            songTimer = 0;
        }
    }

    void RestartSong()
    {
        song.Stop();
        song.Play();
    }
}
