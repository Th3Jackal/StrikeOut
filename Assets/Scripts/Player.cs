using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] SpriteRenderer ball;
    [SerializeField] GameObject point1;
    [SerializeField] GameObject point2;
    [SerializeField] GameObject point3;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject ballObj;
    private Color enemyColor = new Color(1, 0, 0, 1);
    public UnityEvent onLossEvent;
    public Image coolImage;
    public float cooldown = 15;
    public int onCooldown;
    int scoreCount = 1;
    public Ball ballR;
    public Countdown countR;
    public SimpleAI aiR;

    // Start is called before the first frame update
    void Start()
    {
        coolImage.fillAmount = 1;
        onCooldown = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(onCooldown == 1)
        {
            iconCooldown();
        }
    }

    public void ActivateAbility()
    {
        if(onCooldown == 0)
        {
            PlayerAbility();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ball" && ball.color == enemyColor)
        {
           LoseRound();
        }
    }

    public void LoseRound()
    {
        onLossEvent.Invoke();
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void EnemyPoints()
    {
        if(scoreCount == 1)
        {
            point1.SetActive(true);
        }
        else if(scoreCount == 2)
        {
            point2.SetActive(true);
        }
        else if(scoreCount == 3)
        {
            point3.SetActive(true);
        }
        scoreCount++;
        if(scoreCount == 4)
        {
            scoreCount = 1;
            Mainmenu();
        }
    }

    public void PlayerAbility()
    {
        coolImage.fillAmount = 1;
        onCooldown = 1;
        ball.color = new Color (0, 0, 1, 1);        
    }

    public void iconCooldown()
    {
        coolImage.fillAmount -= 1 / cooldown * Time.deltaTime;
        if(coolImage.fillAmount <= 0)
        {
            onCooldown = 0;
        }
    }

    public void newRound()
    {
        countR.elapsedTime = 60;
        ball.color = new Color(1, 1, 1, 1);
        ballR.start = 1;
        coolImage.fillAmount = 1;
        onCooldown = 1;
        ballR.bspeed = 0;
        aiR.onCooldown = 1;
        aiR.coolImage.fillAmount = 1;
        player.transform.position = new Vector3(-6.1f, 0.03979897f, 0);
        enemy.transform.position = new Vector3(6.1f, 0.03979897f, 0);
        ballObj.transform.position = new Vector3(0, -2.4f, 0);
    }
}
