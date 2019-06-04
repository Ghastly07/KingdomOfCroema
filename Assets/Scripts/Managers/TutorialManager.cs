using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : Singleton<TutorialManager>
{
    public GameObject messageBox;
    public Text messageBoxText;

    private int enemiesDefeatedCount;

    void Awake()
    {
        messageBoxText.text = "Otwierasz oczy. Przed Tobą rozpościera się arena. Czujesz mocny ból głowy. Rozglądasz się dokoła, widzisz tłum gapiów i osobę w białej długiej szacie stojącą nad Tobą. Czujesz, że musisz działać – wstajesz i podchodzisz do niej.";
        messageBox.SetActive(true);
    }

    void Update()
    {
        if (enemiesDefeatedCount >= 3)
        {
            TutorialEnd();
        }
    }

    public void SwitchOffMessageBox()
    {
        messageBox.SetActive(false);
    }

    public void EnemiesDefeated()
    {
        enemiesDefeatedCount++;
    }

    void TutorialEnd()
    {
        messageBoxText.text = "Wygrałeś! Możesz teraz odejść w stronę miasta";
        messageBox.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(Wait(8));
        SceneManager.LoadScene(Data.TownSceneTag);
    }

    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
