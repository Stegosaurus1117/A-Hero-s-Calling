using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//what left
//1-Enemy attack & spawn
//2-Player Classes
//3-Upgrades
//4-UI
public class Attack : MonoBehaviour   
{
    private GameObject player;
    public GameObject Projectile;
    public GameObject expander;
    public GameObject mSlash;
    private GameObject instSlash;
    private GameObject instProjectile;
    private GameObject instExpander;
    
    private LineRenderer LR;



    private bool isFired;
    private bool isAttacking;
    private bool canExpand;

    private float meleeRate;
    private float projectileRate;

    public float projSpeed;
    public float slashSpeed;
    public float expandCD;
    public float knockback;
    //e

    

    Vector3 WorldPosition;
    Vector3 projDestination;
    Vector3 meleeDestination;
    Vector3 playerPos;
    Vector3 mousePos;
    Vector3 attackmousePos;

    public Movement movement;
    Stats StatScript;

  
    // Start is called before the first frame update
    void Start()
    {
        StatScript = GetComponent<Stats>();
        player = GameObject.Find("Player");

        isFired = false;
        isAttacking = false;
        canExpand = true;

        meleeRate = 0.2f;
        projectileRate = 0.2f;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = Camera.main.nearClipPlane;
        WorldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        {
            DoAttack(EType.melee);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !isFired)
        {
            DoAttack(EType.projectile);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canExpand)
        {
            canExpand = false;
            DoAttack(EType.area);
        }

       /* MoveProjectile();
        MoveAttack();*/
    }

    void FireProjectile()
    {
        
        Vector3 MousePos = Input.mousePosition;
        MousePos.z = 0f;

        WorldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        projDestination = WorldPosition;

        playerPos = transform.position;
        mousePos = WorldPosition;

        
        
        //script.damageValue = StatScript.projDmg;

        isFired = true;
        Invoke("DestroyProjectile", 3f);
    }
         
    void DoAttack(EType atkType)
    {
        
        Vector3 MousePos = Input.mousePosition;
        mousePos.z = 0f;

        WorldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        meleeDestination = WorldPosition;
        playerPos = transform.position;
        attackmousePos = WorldPosition;

        switch (atkType)
        {
            case EType.melee:
                //Ability side setup
                instSlash = Instantiate(mSlash, transform.position, transform.rotation, player.transform);
                instSlash.GetComponent<Melee>().SetDefault(StatScript.meleeDmg, 0.2f, slashSpeed, knockback);
                
                //Player side setup, attack rate
                isAttacking = true;
                Invoke("ResetAttack", meleeRate);
                break;
            case EType.projectile:
                instProjectile = Instantiate(Projectile, transform.position, transform.rotation);
                instProjectile.GetComponent<Projectile>().SetDefault(StatScript.projDmg, 3f, projSpeed);

                isFired = true;
                Invoke("ResetProjectile", projectileRate);
                break;
            case EType.area:
                
                instExpander = Instantiate(expander, transform.position, transform.rotation, player.transform);
                    
                instExpander.GetComponent<Expand>().SetDefault(StatScript.expandDmg, 0.5f, expandCD);
                Invoke("ResetExpand", 5f);
                break;
        }
    }

   /* void MoveAttack()
    {
        if (!isAttacking) return;

        Vector3 attackDirection = (attackmousePos - playerPos);
        attackDirection.z = 0f;

        instSlash.transform.position += attackDirection.normalized * slashSpeed * Time.deltaTime;

    }
    void MoveProjectile()
    {
        if (!isFired) return;

        Vector3 projDirection = (mousePos - playerPos);
        projDirection.z = 0f;

        if (instProjectile != null)
        {
            instProjectile.transform.position += projDirection.normalized * projSpeed * Time.deltaTime;
        }
       
    }*/

    void ResetAttack()
    {
        isAttacking = false;
    }

    void ResetProjectile()
    {
        isFired = false;
    }

    void ResetExpand()
    {
        canExpand = true;
    }
}