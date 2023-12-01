using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] AnimationStateChanger animationStateChanger;
    private GameObject hitArea = default;
    //private bool hitting = false;
    [SerializeField] GameObject hitAreaBox;
    //private float hitTime = 0.5f;
    //private float timer = 0f;
    Rigidbody2D rig;
    public int onCool;

    void Start()
    {
        hitArea = transform.GetChild(1).gameObject;
        onCool = 0;
    }

    void Update()
    {
        /*if(hitting)
        {
            timer += Time.deltaTime;

            if(timer >= hitTime)
            {
                timer = 0;
                hitting = false;
                hitArea.SetActive(hitting);
            }
        }*/
    }

    public void HitActive()
    {
        if(onCool == 0)
        {
            StartCoroutine(HitCoroutine());
        }
    }

    IEnumerator HitCoroutine()
    {
        onCool = 1;
        hitAreaBox.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(.75f);
        hitAreaBox.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(.5f);
        onCool = 0;
    }
}
