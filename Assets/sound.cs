using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public float livetime;
    private AudioSource deathsound;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", livetime);
        deathsound = GetComponent<AudioSource>();
        deathsound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
