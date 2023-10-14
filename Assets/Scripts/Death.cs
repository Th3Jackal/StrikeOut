using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject reaper;
    [SerializeField] int seconds = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bean")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void Start()
    {
        Destroy(reaper, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
