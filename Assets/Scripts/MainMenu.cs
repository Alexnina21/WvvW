using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoWin()
    {
        SceneManager.LoadScene("Win");
    }
    public void GoOptions()
    {
        SceneManager.LoadScene("Opt");
    }
    public void GoLoad()
    {
        SceneManager.LoadScene("LoadGame");
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #else
        {
            Application.Quit();
        }
        #endif
    }
}
