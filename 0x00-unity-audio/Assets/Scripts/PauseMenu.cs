using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

/// <summary>
/// Handle all functionnality of pausemenu
/// </summary>
public class PauseMenu : MonoBehaviour
{
    /// <summary>Get the GameObject pauseCanvas to setactive</summary>
    public GameObject PauseCanvas;
    public AudioMixerSnapshot pause;
    public AudioMixerSnapshot play;

    /// <summary>
    /// Activate the pause menu when the player press ESC
    /// </summary>
    public void Pause()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        pause.TransitionTo(.01f);
    }

    /// <summary>
    /// Resume the game when the player press ESC or the resume button
    /// </summary>
    public void Resume()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        play.TransitionTo(.01f);
    }

    /// <summary>
    /// Restart the current level
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Load the MainMenu
    /// </summary>
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        play.TransitionTo(.01f);
    }

    /// <summary>
    /// Load the options
    /// </summary>
    public void Options()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
}
