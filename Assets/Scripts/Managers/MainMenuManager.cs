using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Button startNewGameButton;
    [SerializeField]
    private Button creditsButton;
    [SerializeField]
    private Button exitGameButton;
    [SerializeField]
    private Button creditsReturnButton;

    [SerializeField]
    private CanvasGroup MainMenuWindow;
    [SerializeField]
    private CanvasGroup CreditsWindow;

    [SerializeField]
    private float fadeTime = 1f;

    private WindowType windowToActivate;

    void Start()
    {
        startNewGameButton.onClick.AddListener(StartNewGame);
        creditsButton.onClick.AddListener(ShowCredits);
        creditsReturnButton.onClick.AddListener(ShowMainMenu);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    private void ShowCredits()
    {
        windowToActivate = WindowType.Credits;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(MainMenuWindow.DOFade(0f, fadeTime));
        sequence.Play();
        sequence.OnComplete(OnCompleteSequence);
    }

    private void ShowMainMenu()
    {
        windowToActivate = WindowType.MainMenu;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(CreditsWindow.DOFade(0f, fadeTime));
        sequence.Play();
        sequence.OnComplete(OnCompleteSequence);
    }

    private void OnCompleteSequence()
    {
        Sequence sequence = DOTween.Sequence();

        switch (windowToActivate)
        {
            case WindowType.MainMenu :
            {
                CreditsWindow.gameObject.SetActive(false);
                MainMenuWindow.gameObject.SetActive(true);

                sequence.Append(MainMenuWindow.DOFade(1f, fadeTime));
                sequence.Play();
                break;
            }

            case WindowType.Credits :
            {
                MainMenuWindow.gameObject.SetActive(false);
                CreditsWindow.gameObject.SetActive(true);

                sequence.Append(CreditsWindow.DOFade(1f, fadeTime));
                sequence.Play();
                break;
            }

            default:
                break;
        }

    }

    private void ExitGame()
    {
        Debug.Log("Closing application");
        Application.Quit(0);
    }
}
