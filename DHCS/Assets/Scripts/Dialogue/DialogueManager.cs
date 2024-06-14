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

    public Animator animator;
    public Animator charAnimator;

    void Start()
    {
        sentences = new Queue<string>();
        sprites = new Queue<Sprite>();
    }

    public void StartDialogue(DialogueContent dialogue)
    {
        animator.SetBool("IsOpen", true);
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
        Sprite sprite = sprites.Dequeue();
        charAnimator.SetTrigger("Talk");
        charImage.sprite = sprite;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

    }

    void EndDialogue()
    {
        FindAnyObjectByType<DialogueTrigger>().CloseDialogue();
        animator.SetBool("IsOpen", false);
        Debug.Log("Chatting Ended");
    }
}
