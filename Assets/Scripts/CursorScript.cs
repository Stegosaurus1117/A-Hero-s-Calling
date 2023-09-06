using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.isPlaying)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 8f);
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);

        }

    }
}
