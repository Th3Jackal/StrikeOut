using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] float fall;
    /*[SerializeField] Transform body;*/
    public int jump;
    Rigidbody2D rig;
    Vector2 gravity;
    /*public Transform check;
    public LayerMask ground;
    bool grounded;*/
    

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        gravity = new Vector2(0, -Physics2D.gravity.y);
    }

    void Update()
    {
        /*grounded = Physics2D.OverlapCapsule(check.position, new Vector2(0.56f, .56f), CapsuleDirection2D.Horizontal, 0, ground);*/
        if(Input.GetKeyDown(KeyCode.W))
        {
            rig.AddForce(new Vector3(rig.velocity.x, jump));
        }

        if(rig.velocity.y < 0)
        {
            rig.velocity -= gravity * fall;
        }
    }

    /*public void MoveTransform(Vector3 vel)
    {
        transform.position += vel * speed * Time.deltaTime;
    }*/

    public void MoveRig(Vector3 vel)
    {
        rig.velocity = vel * speed;
        if(vel.magnitude > 0)
        {
            animationStateChanger.ChangeAnimationState("Walk");

            /*if(vel.x > 0)
            {
                body.localScale = new Vector3(1,1,1);
            }
            else if(vel.x < 0)
            {
                body.localScale = new Vector3(-1,1,1);
            }*/
        } 
        else
        {
            animationStateChanger.ChangeAnimationState("Idle");
        }
    }
}
