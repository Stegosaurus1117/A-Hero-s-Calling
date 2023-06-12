using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject cube;
    private LineRenderer LR;
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("Cube");
       
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            MakeLine(cube.transform.position.x, Input.mousePosition.x, cube.transform.position.y, Input.mousePosition.y);
        }*/
        LR = GetComponent<LineRenderer>();

        List<Vector3> pos = new List<Vector3>();
        pos.Add(new Vector3(cube.transform.position.x, cube.transform.position.y));
        pos.Add(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        LR.startWidth = 0.5f;
        LR.endWidth = 0.5f;
        LR.SetPositions(pos.ToArray());
        LR.useWorldSpace = true;
        Debug.Log(Input.mousePosition);
        Debug.Log(cube.transform.position);

    }

    /*void MakeLine(float x1, float x2, float y1, float y2)
    {
        float run = x2 - x1;
        float rise = y2 - y1;
        float m = rise / run;


    }
    */
}