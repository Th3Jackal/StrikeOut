using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class SimpleAI : MonoBehaviour
{
    DiscreteMovement movement;
    [SerializeField] AnimationStateChanger animationStateChanger;
    //[SerializeField] float viewRadius = 500;
    //[SerializeField] bool activated = false;
    [SerializeField] Transform ballTransform;
    [SerializeField] BoxCollider2D hitBox;
    [SerializeField] Transform body;
    [SerializeField] Hit hit;
    [SerializeField] float jump = 5;
    [SerializeField] LayerMask groundMask;
    [SerializeField] SpriteRenderer ballColor;
    Rigidbody2D rig;
    public Image coolImage;
    public float cooldown = 15;
    int jumpCool = 1;
    public float enemySpeed = 2;
    float rightHitBox = .23f;
    float leftHitBox = (.23f * -1);
    public int onCooldown;
    private Color playerColor = new Color(0, 0, 1, 1);

    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<DiscreteMovement>();
        rig = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        coolImage.fillAmount = 1;
        onCooldown = 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Vector3.Distance(transform.position,ballTransform.position) < viewRadius){
            FollowBall();
        }
        else{
            Idle();
        }*/
        Vector3 scale = transform.localScale;

        if(ballTransform.position.x > transform.position.x)
        {
            transform.Translate(enemySpeed * Time.deltaTime, 0, 0);
            animationStateChanger.ChangeAnimationState("Walk");
            body.localScale = new Vector3(-3,3,3);
            //scale.x = Mathf.Abs(scale.x) * -1;
            hitBox.offset = new Vector2(rightHitBox, -2.246499f);
        }
        else if(ballTransform.position.x < transform.position.x)
        {
            transform.Translate(enemySpeed * Time.deltaTime * -1, 0, 0);
            animationStateChanger.ChangeAnimationState("Walk");
            body.localScale = new Vector3(3,3,3);
            //scale.x = Mathf.Abs(scale.x);
            hitBox.offset = new Vector2(leftHitBox, -2.246499f);
        }
        if((ballTransform.position.x + transform.position.x) <= 1 || (ballTransform.position.x - transform.position.x) >= -1)
        {
            //body.localScale = new Vector3(3,3,3);
            //hitBox.offset = new Vector2(rightHitBox, -2.246499f);
            hit.HitActive();
        }
        if(ballTransform.position.y >= 0 && (ballTransform.position.x - transform.position.x) < .75f && jumpCool == 1)
        {
            jumpCool = 0;
            StartCoroutine(JumpCoroutine());
        }
        if(onCooldown == 1)
        {
            iconCooldown();
        }
        if(onCooldown == 0 && ballColor.color == playerColor)
        {
            EnemyAbility();
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

    public void Jump()
    {
        //rig.AddForce(new Vector3(0, jump, 0), ForceMode2D.Impulse);
        //Vector3 vel = Vector3.zero;
        if(Physics2D.OverlapCircleAll(transform.position - new Vector3(5, 2f, 0),2f,groundMask).Length > 0)
        {
            rig.AddForce(new Vector3(0, jump, 0), ForceMode2D.Impulse);
        }
    }

    IEnumerator JumpCoroutine()
    {
        Jump();
        yield return new WaitForSeconds(2);
        jumpCool = 1;
    }

    public void EnemyAbility()
    {
        coolImage.fillAmount = 1;
        onCooldown = 1;
        ballColor.color = new Color (1, 0, 0, 1);
    }

    public void iconCooldown()
    {
        coolImage.fillAmount -= 1 / cooldown * Time.deltaTime;
        if(coolImage.fillAmount <= 0)
        {
            onCooldown = 0;
        }
    }
}