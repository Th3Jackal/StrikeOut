using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jump = 5;
    [SerializeField] LayerMask groundMask;
    [SerializeField] AnimationStateChanger animationStateChanger;
    [SerializeField] Hit hit;
    [SerializeField] Transform body;
    [SerializeField] BoxCollider2D hitBox;
    
    Rigidbody2D rig;

    float enemySpeed;
    //int jumpCool = 1;
    //float rightHitBox = -5.168638f;
    //float leftHitBox = (-5.168638f - 0.9324365f);
    

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        //Vector3 vel = Vector3.zero;

        /*if(this.gameObject.name == "Enemy")
        {
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
        }*/
    }

    public void MoveRig(Vector3 vel)
    {
        vel.x *= speed;
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

    public void MoveToward(Vector3 targetPosition){
        /*Vector3 direction = (targetPosition - transform.position).normalized;
        //direction = Vector3.Normalize(direction);
        MoveRig(direction);
        if(direction.x < 0)
        {
            body.localScale = new Vector3(3,3,3);
            hitBox.offset = new Vector2(rightHitBox, -2.246499f);
        }
        else if(direction.x > 0)
        {
            body.localScale = new Vector3(-3,3,3);
            hitBox.offset = new Vector2(leftHitBox, -2.246499f);
        }
        //MoveRig(direction);
        if(direction.x < 1)
        {
            //body.localScale = new Vector3(3,3,3);
            //hitBox.offset = new Vector2(rightHitBox, -2.246499f);
            hit.HitActive();
        }
        if(direction.y >= 0.5f && direction.x < 1 && jumpCool == 1)
        {
            jumpCool = 0;
            StartCoroutine(JumpCoroutine());
            
        }*/
        
    }

    public void Stop(){
        MoveRig(Vector3.zero);
    }

    /*void OnDrawGizmos(){
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position-new Vector3(0,1f,0),.25f);
    }*/

    public void Jump()
    {
        //rig.AddForce(new Vector3(0, jump, 0), ForceMode2D.Impulse);
        //Vector3 vel = Vector3.zero;
        if(Physics2D.OverlapCircleAll(transform.position - new Vector3(1, 2f, 0),2f,groundMask).Length > 0)
        {
            rig.AddForce(new Vector3(0, jump, 0), ForceMode2D.Impulse);
        }
    }

    /*IEnumerator JumpCoroutine()
    {
        Jump();
        yield return new WaitForSeconds(2);
        jumpCool = 1;
    }*/
}
