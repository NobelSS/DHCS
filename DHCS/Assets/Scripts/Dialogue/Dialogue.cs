using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] sentences;
    public Image Bob;

    public Sprite BobNeutral;
    public Sprite BobSmiling;
    public Sprite BobShock;
    
    public float textSpeed;
    public bool isDialoguePlaying = false;
    private int index = 0;
    private PlayerStateManager player;
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Theodore = GameObject.Find("Theodore");
        if (Theodore != null)
        {   
            player = Theodore.GetComponent<PlayerStateManager>();
            rb = Theodore.GetComponent<Rigidbody2D>();
        }
        animator = GetComponent<Animator>();
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(index);
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == sentences[index] )
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = sentences[index];
            }
        }

        if (isDialoguePlaying)
        {
            player.enabled = false;
        }
        else
        {
            player.enabled = true;
        }

        // Expression Change
        if (index == 2)
        {
            Bob.sprite = BobSmiling;
        }
        else if (index == 6)
        {
            Bob.sprite = BobShock;
        }
        else
        {
            Bob.sprite = BobNeutral;
        }

        // Dialogue breaks
        if(index == 3)
        {
            isDialoguePlaying = false;
            StartCoroutine(HandleDialogueBreak());

            if(Mathf.Abs(rb.velocity.x) > 0)
            {

                Invoke("NextLine", 3f);
            }
           
        }
    }

    void StartDialogue()
    {
        animator.SetTrigger("Enter");
        index = 0;
        isDialoguePlaying = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        isDialoguePlaying = true;
        if (index < sentences.Length - 1)
        {
            animator.SetTrigger("Enter");
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        animator.SetTrigger("Exit");
        isDialoguePlaying = false;
    }

    IEnumerator HandleDialogueBreak()
    {
        EndDialogue();
        yield return new WaitForSeconds(2f); // Adjust the wait time as needed

    
    }
}
