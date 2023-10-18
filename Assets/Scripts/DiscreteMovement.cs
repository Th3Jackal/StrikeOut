using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jump = 5;
    [SerializeField] LayerMask groundMask;
    [SerializeField] AnimationStateChanger animationStateChanger;
    Rigidbody2D rig;
    

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    public void MoveRig(Vector3 vel)
    {
        vel *= speed;
        vel.y = rig.velocity.y;
        rig.velocity = vel;
        if(vel.magnitude > 0)
        {
            animationStateChanger.ChangeAnimationState("Walk");
        } 
        else
        {
            animationStateChanger.ChangeAnimationState("Idle");
        }
    }

    /*void OnDrawGizmos(){
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position-new Vector3(0,1f,0),.25f);
    }*/

    public void Jump()
    {
        //rig.AddForce(new Vector3(0, jump, 0), ForceMode2D.Impulse);
        //Vector3 vel = Vector3.zero;
        if(Physics2D.OverlapCircleAll(transform.position - new Vector3(5, 2f, 0),2f,groundMask).Length > 0)
        {
            rig.AddForce(new Vector3(0, jump, 0), ForceMode2D.Impulse);
        }
    }
}
