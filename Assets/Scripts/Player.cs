using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] SpriteRenderer ball;
    private Color enemyColor = new Color(1, 0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            ActivateAbility();
        }
    }

    void ActivateAbility()
    {
        ball.color = new Color (0, 0, 1, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ball" && ball.color == enemyColor)
        {
           SceneManager.LoadScene("Main Menu");
        }
    }
}
