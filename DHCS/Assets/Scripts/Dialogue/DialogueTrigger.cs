using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogueScene;
    public DialogueContent dialogue;
    public string dialogueID;

    private void Start()
    {
        CloseDialogue();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Time.timeScale = 0f;
        if (other.CompareTag("Player"))
        {
            
            if (DialogueStateTracker.triggeredDialogues.ContainsKey(dialogueID) && DialogueStateTracker.triggeredDialogues[dialogueID])
            {
                // Dialogue has already been triggered, do nothing
                return;
            }
            CloseDialogue();
            // Trigger the dialogue
            dialogueScene.SetActive(true);
            TriggerDialogue();

            // Mark the dialogue as triggered
            DialogueStateTracker.triggeredDialogues[dialogueID] = true;
            
        }
            
    }

    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);

    }

    public void CloseDialogue()
    {
        dialogueScene.SetActive(false);
        //Time.timeScale = 1f;
    }
}
