using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject cube;
    private LineRenderer LR;
    Vector3 WorldPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("Cube");
        
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = Camera.main.nearClipPlane;
        WorldPosition = Camera.main.ScreenToWorldPoint(MousePos);
       
        LR = GetComponent<LineRenderer>();

        List<Vector3> pos = new List<Vector3>();
        pos.Add(new Vector3(cube.transform.position.x, cube.transform.position.y));
        pos.Add(new Vector3(WorldPosition.x, WorldPosition.y));
        LR.startWidth = 0.5f;
        LR.endWidth = 0.5f;
        LR.SetPositions(pos.ToArray());
        LR.useWorldSpace = true;
        Debug.Log(WorldPosition);
        Debug.Log(cube.transform.position);

    }

    
}