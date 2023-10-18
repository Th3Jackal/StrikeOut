using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] AnimationStateChanger animationStateChanger;
    private GameObject hitArea = default;
    private bool hitting = false;
    private float hitTime = 0.5f;
    private float timer = 0f;
    Rigidbody2D rig;

    void Start()
    {
        hitArea = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HitActive();
        }

        if(hitting)
        {
            timer += Time.deltaTime;

            if(timer >= hitTime)
            {
                timer = 0;
                hitting = false;
                hitArea.SetActive(hitting);
            }
        }
    }

    private void HitActive()
    {
        hitting = true;
        hitArea.SetActive(hitting);
    }
}
