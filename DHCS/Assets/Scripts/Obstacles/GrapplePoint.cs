using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    Transform grapplePos;
    SpriteRenderer sr;
    GameObject character;
    internal Animator animator;
    float distance;
    [SerializeField] public DialogueManager dm;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        grapplePos = GetComponent<Transform>();
        character = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (character != null)
        {
            distance = Vector2.Distance(grapplePos.position, character.transform.position);
            if (distance < 5)
            {
                animator.SetBool("Distance", true);
            }
            else
            {
                animator.SetBool("Distance", false);
                sr.color = Color.white;
            }
        }
        if (Input.GetButtonDown("Fire1") && !dm.inDialogue) 
        {
        if (character != null)
        {
            if(distance < 5)
            {
                
                PlayerStateManager playerStateManager = character.GetComponent<PlayerStateManager>();
                PlayerGrappleState pgs = playerStateManager.grappleState;
                if (playerStateManager != null)
                {
                    playerStateManager.changeState(pgs);
                }
            }
        }
        }
    }

}
