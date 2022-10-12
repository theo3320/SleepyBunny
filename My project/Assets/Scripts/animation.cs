using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class animation : MonoBehaviour

{
    NewThirdPerson nfp;
    [SerializeField] Raycasts rc;   
    //public groundedcollider isGroundedScript;
    public bool isGrounded;
    public bool pickMeUp;
    public bool isPulling;

    bool wasGrounded;
    bool wasFalling;
    float startOfFall;

    private Vector3  enterHeight;
    private Vector3  exitHeight;

    public float fallHeight;   


    public Rigidbody RidgedBody;
    public bool isAlive = true;
    public double _decelerationTolerance = 0;
    //public Vector3 SpawnPoint;
    public bool canKillOnTouch;

    private GameMaster gm;
    private Vector3 playerOrigin;
    bool isFalling
    {
        get
        { return (!rc.grounded && RidgedBody.velocity.y < 0); }
    }



    public void Start()
    {
        
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;

    }

    public Animator anim;
    public void Update()
    {
       
       

        if (Input.GetAxisRaw("Vertical") == 0f || Input.GetAxisRaw("Horizontal") == 0f)
        {
            anim.SetBool("jump", false);
            anim.SetBool("idle", true);
            anim.SetBool("walk", false);
            anim.SetBool("push", false);

        }
        if (Input.GetAxisRaw("Vertical") != 0f || Input.GetAxisRaw("Horizontal") != 0f)
        {
            anim.SetBool("walk", true);
            anim.SetBool("jump", false);
            anim.SetBool("idle", false);
            anim.SetBool("push", false);

        }


        if (rc.grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("walk", false);
            anim.SetBool("jump", true);
            anim.SetBool("idle", false);
            anim.SetBool("push", false);
        }

        if (rc.pushOrPull && Input.GetKey(KeyCode.E))
        {
            anim.SetBool("walk", false);
            anim.SetBool("jump", false);
            anim.SetBool("idle", false);
            anim.SetBool("push", true);
            isPulling = true;
        }
        
        if (rc.pushOrPull && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("walk", false);
            anim.SetBool("jump", true);
            anim.SetBool("idle", false);
            anim.SetBool("push", false);
        }

   



    }

   

    //IEnumerator Respawn()
    //{   
    //    yield return new WaitForSeconds(0.5f);
    //    transform.position = SpawnPoint;
    //    IsAlive = false;
    //    yield return new WaitForSeconds(1);
    //    Debug.Log("Respawn");
    //}


}





