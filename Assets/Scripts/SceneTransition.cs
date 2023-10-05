using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] Color fadeColor = Color.black;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] float fadeTime2 = 1.5f;
    [SerializeField] float tSpeed = 1.0f;

    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        FadeIn();
    }

    // Update is called once per frame
    void Awake()
    {
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
    }

    void FadeIn()
    {
        StartCoroutine(FadeInRoutine());
        IEnumerator FadeInRoutine()
        {
            float timer = 0f;
            while(timer < fadeTime)
            {
                fadeImage.transform.localScale += scaleChange * tSpeed;
                timer+=Time.deltaTime;
                yield return null;
            }
            fadeImage.color = Color.clear;
            yield return null;
        }
    }

     public void FadeOut(string sceneName)
    {
        StartCoroutine(FadeOutRoutine());
        IEnumerator FadeOutRoutine()
        {
            float timer = 0f;
            while(timer < fadeTime2)
            {
                fadeImage.color = new Color(fadeColor.r,fadeColor.g,fadeColor.b,1);
                fadeImage.transform.localScale += -scaleChange * tSpeed;
                timer+=Time.deltaTime;
                yield return null;
            }
            yield return null;
            SceneManager.LoadScene(sceneName);
        }
    }
}
