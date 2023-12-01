using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMHandler : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Stage 1");
    }

    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void BackMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
