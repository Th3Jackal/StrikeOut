using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMHandler : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Stage 1");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("Settings");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
