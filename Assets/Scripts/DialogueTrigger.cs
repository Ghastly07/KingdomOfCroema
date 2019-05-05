using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject ClickKeyInfo;

    [SerializeField]
    private DialogueController dialogueController;

    public void TriggerDialogue()
    {
        dialogueController.StartDialogue(dialogue);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(Data.PlayerTag) && Input.GetKey(KeyCode.E))
        {
            ClickKeyInfo.SetActive(false);
            TriggerDialogue();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ClickKeyInfo.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ClickKeyInfo.SetActive(true);
    }
}
