using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Queue<Sprite> sprites;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image charImage;
    private string currSentence;
    public bool inDialogue = false;
    public PlayerStateManager theodore;
    //public Animator animator;


    void Start()
    {
        
        sentences = new Queue<string>();
        sprites = new Queue<Sprite>();
        inDialogue = false;
    }

    public void StartDialogue(DialogueContent dialogue)
    {
        //theodore.rb.velocity = Vector2.zero;
        //theodore.changeState(theodore.idleState);
        inDialogue = true;
        //animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        sprites.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach(Sprite sprite in dialogue.sprites)
        {
            sprites.Enqueue(sprite);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        currSentence = sentence;
        Sprite sprite = sprites.Dequeue();
        charImage.sprite = sprite;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void CompleteSentence()
    {
        if(dialogueText.text != currSentence)
        {
            dialogueText.text = currSentence; 
        }
        else
        {
            StopAllCoroutines();
            DisplayNextSentence();
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (dialogueText.text != currSentence) { 
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
        }

    }

    void EndDialogue()
    {
        inDialogue = false;
        FindAnyObjectByType<DialogueTrigger>().CloseDialogue();
        //animator.SetBool("IsOpen", false);
        //Debug.Log("Chatting Ended");
    }
}
