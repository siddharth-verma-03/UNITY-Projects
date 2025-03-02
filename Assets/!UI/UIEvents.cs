using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    private bool isPaused = false;
    private bool isSFXEnabled;

    private void Start()
    {
        // Load saved audio state (1 = Enabled, 0 = Disabled)
        isSFXEnabled = PlayerPrefs.GetInt("SFXEnabled", 1) == 1;
        ApplyAudioSettings();
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            Debug.Log("Game Paused");
        }
    }

    public void ContinueGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            Debug.Log("Game Resumed");
        }
    }

    public void DisableSFX()
    {
        isSFXEnabled = false;
        PlayerPrefs.SetInt("SFXEnabled", 0);
        PlayerPrefs.Save();
        ApplyAudioSettings();
        Debug.Log("All SFX muted except 'GameSound'.");
    }

    public void EnableSFX()
    {
        isSFXEnabled = true;
        PlayerPrefs.SetInt("SFXEnabled", 1);
        PlayerPrefs.Save();
        ApplyAudioSettings();
        Debug.Log("All SFX unmuted except 'GameSound'.");
    }

    private void ApplyAudioSettings()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in allAudioSources)
        {
            if (source.gameObject.name != "GameSound")
            {
                source.mute = !isSFXEnabled;
            }
        }
    }

    private void Update()
    {
        // Ensure newly spawned audio sources follow the SFX setting
        ApplyAudioSettings();
    }
}
