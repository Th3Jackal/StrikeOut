using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovementController : MonoBehaviour
{
    [SerializeField] DiscreteMovement movement;
    [SerializeField] Transform body;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] BoxCollider2D hitBox;

    float rightHitBox = -5.168638f;
    float leftHitBox = (-5.168638f - 0.9324365f);
    
    /*Rigidbody2D rig;
    public float jump;*/
    

    void Awake(){
    }

    void Start(){
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animationStateChanger.ChangeAnimationState("Hit");
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            movement.Jump();
        }
    }

    void FixedUpdate(){
        Vector3 vel = Vector3.zero;

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
            hitBox.offset = new Vector2(rightHitBox, -2.246499f);
        }
        else if(vel.x < 0)
        {
            body.localScale = new Vector3(-3,3,3);
            hitBox.offset = new Vector2(leftHitBox, -2.246499f);
        }
        movement.MoveRig(vel);
    }

}