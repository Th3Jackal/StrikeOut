using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    DiscreteMovement movement;
    [SerializeField] float viewRadius = 55;
    //[SerializeField] bool activated = false;
    [SerializeField] Transform ballTransform;
    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<DiscreteMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,ballTransform.position) < viewRadius){
            FollowBall();
        }
        else{
            Idle();
        }
    }

    public void FollowBall(){
        //activated = true;
        movement.MoveToward(ballTransform.position);
    }

    public void Idle(){
        //do nothing
        movement.Stop();
    }

}