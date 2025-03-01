using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    private bool isPaused = false;

    public void GameExit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0; // Pause game
            isPaused = true;
            Debug.Log("Game Paused");
        }
    }

    public void ContinueGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1; // Resume game
            isPaused = false;
            Debug.Log("Game Resumed");
        }
    }
}
