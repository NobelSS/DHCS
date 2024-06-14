using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] private GameObject windowObs;
    [SerializeField] private Material tempIndicator;
    private Renderer windowRenderer;
    private bool windowBroken = false;
    private bool isInWindow = false;
    private BoxCollider2D collider;
    private GameController HP;
    private PlayerStateManager player;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        windowRenderer = windowObs.GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        GameObject Theodore = GameObject.Find("Theodore");
        if (Theodore != null)
        {
            // Get the GameController script attached to Theodore
            HP = Theodore.GetComponent<GameController>();
            
            player = Theodore.GetComponent<PlayerStateManager>();
        }
        collider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(windowBroken)
        {
            collider.enabled = false;
        }
    }

    private IEnumerator ChangeMaterialDelayed(Material newMaterial, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetTrigger("Break");
        windowBroken = true;
        if(isInWindow && HP != null && player.currentState != player.hideState)
        {
            HP.currHP--;
        }
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string currentTag = gameObject.tag;
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeMaterialDelayed(tempIndicator, 0.5f));
            isInWindow = true;
            AudioManager.Instance.PlaySFX("window");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isInWindow = false;
        }
    }
}
