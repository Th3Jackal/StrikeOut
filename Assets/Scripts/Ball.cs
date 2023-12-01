using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    public float bspeed = 1;
    public Vector2 bdirection = Vector2.zero.normalized;
    public Rigidbody2D rigb;
    public SpriteRenderer ballsprite;
    int directionchance = 0;
    private Color playerColor = new Color(0, 0, 1, 1);
    private Color enemyColor = new Color(1, 0, 0, 1);
    public int start = 1;

    void Awake()
    {
        rigb = GetComponent<Rigidbody2D>();
        //bdirection = Vector2.one.normalized;
    }

    void Start()
    {

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
            bspeed = 5;
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
            directionchance = Random.Range(0, 1);
            if(directionchance == 0)
            {
                bspeed += 1;
                bdirection.x = -bdirection.x;
            }
            else if(directionchance == 1)
            {
                bspeed += 1;
                bdirection.x = -bdirection.x;
                bdirection.y = -bdirection.y;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "HitArea" || collision.gameObject.name == "EnemyHitArea")
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }

}
