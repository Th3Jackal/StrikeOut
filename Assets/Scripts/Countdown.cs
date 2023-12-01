using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public Ball ball;
    public float elapsedTime;
    
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 60;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime -= Time.deltaTime;
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        if(seconds >= 0){
            timerText.text = string.Format("{00}", seconds);
        }
        if(seconds <= 0)
        {
            ball.bspeed = 50;
        }
    }
}
