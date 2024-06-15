using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitDoor : MonoBehaviour
{
    public Sprite opened;
    public Sprite closed;
    public string sceneName;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {

            spriteRenderer.sprite = opened;
            
            SceneManager.LoadScene(sceneName);
            
            
    
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            spriteRenderer.sprite = closed;
        }
    }
}
