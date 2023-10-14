using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] Image sceneT;
    [SerializeField] Color tColor = Color.blue;
    [SerializeField] float tTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        tEffect();
    }

    void tEffect() 
    {
        StartCoroutine(tRoutine());
        IEnumerator tRoutine()
        {
            float timer = 0f;
            while(timer < tTime)
            {
                timer += Time.deltaTime;
                sceneT.color = new Color(tColor.r,tColor.g,tColor.b,0);
                yield return null;
            }
            sceneT.color = Color.clear;
            yield return null;
        }
    }
}
