using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseWindow;
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private Button resumeButton;

    private bool isGamePaused;

    private void Start()
    {
        isGamePaused = false;

        exitButton.onClick.AddListener(ExitToMainMenu);
        resumeButton.onClick.AddListener(ResumeGameplay);
        pauseWindow.SetActive(false);
    }

    private void Update()
    {
        if (isGamePaused)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGameplay();
        }
    }

    private void PauseGameplay()
    {
        Time.timeScale = 0;
        pauseWindow.SetActive(true);
    }

    private void ResumeGameplay()
    {
        Time.timeScale = 1;
        pauseWindow.SetActive(false);
    }

    private void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
