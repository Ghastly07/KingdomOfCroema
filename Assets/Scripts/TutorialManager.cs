using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject messageBox;
    public Text messageBoxText;

    private int enemiesDefeatedCount;

    void Awake()
    {
        messageBox.SetActive(true);
    }

    void Start()
    {
        
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

    void TutorialEnd()
    {
        SceneManager.LoadScene("TownScene",LoadSceneMode.Single);
    }
}
