using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    [SerializeField]
    private DialogueController dialogueController;

    public void TriggerDialogue()
    {
        dialogueController.StartDialogue(dialogue);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E)) {
            TriggerDialogue();
        }
    }
}
