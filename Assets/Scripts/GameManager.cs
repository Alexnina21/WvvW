using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void Win()
    {
        SceneManager.LoadScene("Win");
    }
}
