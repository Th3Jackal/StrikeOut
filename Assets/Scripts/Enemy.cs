using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] SpriteRenderer ball;
    private Color playerColor = new Color(0, 0, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateAbility()
    {
        ball.color = new Color (1, 0, 0, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ball" && ball.color == playerColor)
        {
           SceneManager.LoadScene("Main Menu");
        }
    }
}