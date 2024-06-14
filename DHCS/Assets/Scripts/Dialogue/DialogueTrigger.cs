using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogueScene;
    public DialogueContent dialogue;
    int count = 0;

    private void Start()
    {
        CloseDialogue();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Time.timeScale = 0f;
        
        if(count == 0) {
            dialogueScene.SetActive(true);
            TriggerDialogue();
        }
        count = 1;
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
