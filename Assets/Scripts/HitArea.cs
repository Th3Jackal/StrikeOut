using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    [SerializeField] SpriteRenderer ball;
    [SerializeField] Rigidbody2D rigb;
    int directionnum = 0;
    public Ball ballcs;

    void Awake()
    {
        rigb = GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "ball" && this.gameObject.name == "HitArea")
        {
            ball.color = new Color (0, 0, 1, 1);
        }

        if(collision.gameObject.name == "ball" && this.gameObject.name == "EnemyHitArea")
        {
            ball.color = new Color (1, 0, 0, 1);
        }

        if(collision.gameObject.CompareTag("Ball"))
        {
            if(directionnum == 0)
            {
                ballcs.bspeed += 1;
                ballcs.bdirection.x = -ballcs.bdirection.x;
                directionnum = 1;
            }
            else if(directionnum == 1)
            {
                ballcs.bspeed += 1;
                ballcs.bdirection.y = -ballcs.bdirection.y;
                directionnum = 0;
            }
        }
    }
}