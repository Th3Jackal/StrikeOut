using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float bspeed = 1;
    public Vector2 bdirection;
    public Rigidbody2D rigb;
    public SpriteRenderer ballsprite;
    int directionchance = 0;
    private Color playerColor = new Color(0, 0, 1, 1);
    private Color enemyColor = new Color(1, 0, 0, 1);
    private int start = 1;

    void Awake()
    {
        rigb = GetComponent<Rigidbody2D>();
        //bdirection = Vector2.one.normalized;
    }

    void FixedUpdate()
    {
        rigb.velocity = bdirection * bspeed;
    }

    void Update()
    {
        if((ballsprite.color == playerColor || ballsprite.color == enemyColor) && start == 1)
        {
            bdirection = Vector2.one.normalized;
            start = 0;
        }
    }

    public void MoveRigb(Vector3 vel)
    {
        rigb.velocity = vel * bspeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("TB"))
        {
            bdirection.y = -bdirection.y;
        }

        else if(collision.gameObject.CompareTag("LR"))
        {
            bdirection.x = -bdirection.x;
        }
        
        else if(collision.gameObject.CompareTag("Hit"))
        {
            Debug.Log("11");
            directionchance = Random.Range(0, 1);
            Debug.Log("12");
            if(directionchance == 0)
            {
                Debug.Log("13");
                bspeed += 1;
                Debug.Log("14");
                bdirection.x = -bdirection.x;
            }
            else if(directionchance == 1)
            {
                Debug.Log("15");
                bspeed += 1;
                Debug.Log("16");
                bdirection.y = -bdirection.y;
            }
        }
    }

}
