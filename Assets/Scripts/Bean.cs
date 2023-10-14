using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject scored;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Point(Clone)")
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
            ScoreText.instance.increaseScore();
            Destroy(collision.gameObject);
        }
    }
}
