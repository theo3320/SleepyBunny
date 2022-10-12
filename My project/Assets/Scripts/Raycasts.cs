using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasts : MonoBehaviour
{
    //Scripts in Use
    NewThirdPerson ntp;

    //Player Bool List
    public bool grounded;
    public bool falling;
    public bool alive;
    public bool climb;
    public bool pushOrPull;
    public bool soft;
    public bool canKill;
    


    //RayCast Lengths

    [Range(0, .1f)] public float rayCastHeight;
    [Range(0,1)]    public float range;
    [Range(0, 5)]   public float groundedDistance;


    public void Start()
    {
        alive = true;
    }

    isSoft sft;
    killOnTouch kot;
    //Grounded Check
    public void Grounded()
    {
        sft = GetComponent<isSoft>();
        kot = GetComponent<killOnTouch>();

        RaycastHit groundHit;
        float distance = groundedDistance;
        Vector3 dir = new Vector3(0, -1);
        if (Physics.Raycast(transform.position, dir, out groundHit, distance))
        {
            sft = groundHit.transform.GetComponent<isSoft>();
            kot = groundHit.transform.GetComponent<killOnTouch>();

            grounded = true;

            if(sft !=null)
            {soft = true;}

            if (kot !=null)
            {canKill = true;}
        }
        else
        {
            grounded = false;
            soft     = false;
            canKill = false;
        }




        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.DrawRay (transform.position, dir* groundedDistance, Color.yellow, 1);
                }
    }

    public void Climbing()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {

            if (hit.transform.gameObject.CompareTag("Climb"))
            {
                climb = true;
                Debug.Log("Scramble Up Here");
            }

            else
            { climb = false; }
            

        }
    }
    OtherGrab target;
    public void PickUp()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
        RaycastHit hit;
            Vector3 eyeCast = transform.position + new Vector3(0, rayCastHeight);

            Debug.DrawRay(eyeCast, transform.forward *range, Color.red, 3);
            if (Physics.Raycast(eyeCast, transform.forward, out hit, range))
            {
                target = hit.transform.GetComponent<OtherGrab>();
                Debug.Log(target.name);
                if (target !=null)
                {
                    target.PickUp();
                }
                
            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            target.LetGo();
        }

    }

    //Fall Damage Soft



    private void Update()
    {
        Grounded();
        Climbing();
        PickUp();

    }



}