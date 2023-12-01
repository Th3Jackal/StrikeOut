using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] SpriteRenderer ball;
    [SerializeField] GameObject point1;
    [SerializeField] GameObject point2;
    [SerializeField] GameObject point3;
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject ballObj;
    int scoreCount = 1;
    public UnityEvent onWinEvent;
    private Color playerColor = new Color(0, 0, 1, 1);
    public Ball ballR;
    public Countdown countR;
    public SimpleAI aiR;
    public Player playR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ball" && ball.color == playerColor)
        {
           WinRound();
        }
    }

    public void WinRound()
    {
        onWinEvent.Invoke();
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void PlayerPoints()
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

    public void newRound()
    {
        countR.elapsedTime = 60;
        ball.color = new Color(1, 1, 1, 1);
        ballR.start = 1;
        playR.coolImage.fillAmount = 1;
        playR.onCooldown = 1;
        ballR.bspeed = 0;
        aiR.onCooldown = 1;
        aiR.coolImage.fillAmount = 1;
        player.transform.position = new Vector3(-6.1f, 0.03979897f, 0);
        enemy.transform.position = new Vector3(6.1f, 0.03979897f, 0);
        ballObj.transform.position = new Vector3(0, -2.4f, 0);
    }
}