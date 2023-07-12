using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject cube;
    public GameObject Projectile;
    public GameObject expander;
    public GameObject mSlash;
    private GameObject instSlash;
    private GameObject instProjectile;
    
    private LineRenderer LR;



    private bool isFired;
    private bool isAttacking;

    public float projSpeed;
    public float slashSpeed;

    Vector3 WorldPosition;
    Vector3 projDestination;
    Vector3 meleeDestination;
    Vector3 cubePos;
    Vector3 mousePos;
    Vector3 attackmousePos;

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
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        {
            DoAttack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !isFired)
        {
            FireProjectile();
        }
       

        MoveProjectile();
        MoveAttack();
    }

    void FireProjectile()
    {
        
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = 0f;

        WorldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        projDestination = WorldPosition;

        cubePos = transform.position;
        mousePos = WorldPosition;

        instProjectile = Instantiate(Projectile, transform.position, transform.rotation);

        isFired = true;
        Invoke("DestroyProjectile", 3f);
    }

    void DoAttack()
    {
        
        Vector3 MousePos = Input.mousePosition;
        mousePos.z = 0f;

        WorldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        meleeDestination = WorldPosition;
        cubePos = transform.position;
        attackmousePos = WorldPosition;

        instSlash = Instantiate(mSlash, transform.position, transform.rotation);

        isAttacking = true;
        Invoke("ResetAttack", 0.2f);


        
    }
    void MoveAttack()
    {
        if (!isAttacking) return;

        Vector3 attackDirection = (attackmousePos - cubePos);
        attackDirection.z = 0f;

        instSlash.transform.position += attackDirection.normalized * slashSpeed * Time.deltaTime;

    }
    void MoveProjectile()
    {
        if (!isFired) return;

        Vector3 projDirection = (mousePos - cubePos);
        projDirection.z = 0f;

        instProjectile.transform.position += projDirection.normalized * projSpeed * Time.deltaTime; //+ movement.playerVelocity;
    }

    void DestroyProjectile()
    {
        Destroy(instProjectile);
        isFired = false;
    }

    void ResetAttack()
    {
        Destroy(instSlash);
        isAttacking = false;
    }
  
    
}