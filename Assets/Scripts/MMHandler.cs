using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
