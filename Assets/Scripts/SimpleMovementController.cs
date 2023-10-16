using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovementController : MonoBehaviour
{
    [SerializeField] DiscreteMovement movement;
    [SerializeField] Transform body;
    
    /*Rigidbody2D rig;
    public float jump;*/
    

    void Awake(){
    }

    void Start(){
    }

    void FixedUpdate(){
        Vector3 vel = Vector3.zero;

        /*if(Input.GetKeyDown(KeyCode.W))
        {
            rig.AddForce(new Vector3(rig.velocity.x, jump));
        }*/
        if(Input.GetKey(KeyCode.S))
        {
            vel.y = -1;
        }
        if(Input.GetKey(KeyCode.A))
        {
            vel.x = -1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            vel.x = 1;
        }

        if(vel.x > 0)
        {
            body.localScale = new Vector3(3,3,3);
        }
        else if(vel.x < 0)
        {
            body.localScale = new Vector3(-3,3,3);
        }

        movement.MoveRig(vel);
    }

}