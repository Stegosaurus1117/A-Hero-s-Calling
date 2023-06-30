using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject cube;
    public GameObject Projectile;
    public GameObject expander;
    private GameObject instProjectile;
    private LineRenderer LR;


    private bool isFired;

    public float projSpeed;

    Vector3 WorldPosition;
    Vector3 projDestination;
    Vector3 cubePos;
    Vector3 mousePos; 

    public Movement movement;

  
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("Cube");

        isFired = false;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = Camera.main.nearClipPlane;
        WorldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        

        if (Input.GetKeyDown(KeyCode.Mouse1) && !isFired)
        {
            FireProjectile();
        }

        MoveProjectile();
    }

    void FireProjectile()
    {
        
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = 0f;

        WorldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        projDestination = WorldPosition;

        cubePos = transform.position;
        mousePos = WorldPosition;

        instProjectile = Instantiate(Projectile, transform.position, Quaternion.identity);

        isFired = true;
        Invoke("DestroyProjectile", 3f);
    }

    void MoveProjectile()
    {
        if (!isFired) return;

        Vector3 projDirection = (mousePos - cubePos); ;
        projDirection.z = 0f;

        instProjectile.transform.position += projDirection.normalized * projSpeed * Time.deltaTime; //+ movement.playerVelocity;
    }

    void DestroyProjectile()
    {
        Destroy(instProjectile);
        isFired = false;
    }
  
}