using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    [SerializeField] GameObject scored;
    [SerializeField] int seconds = 1;
    [SerializeField] AudioClip clip;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bean")
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bean")
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
    
    
    void Start()
    {
        Destroy(scored, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
