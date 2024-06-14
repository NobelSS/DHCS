using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    private float time;
    public override void EnterState(PlayerStateManager player)
    {
        AudioManager.Instance.PlaySFX("death");
        Debug.Log("is dead");
        player.gameOverScreen.SetActive(true);
    }

    public override void ExitState(PlayerStateManager player)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Debug.Log("Masuk exit");
        player.gameOverScreen.SetActive(false);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        time += Time.deltaTime;
        if(time < 2f)
        {
             player.rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else if(Input.GetButtonDown("Fire1"))
        {
            player.HP.Respawn();
            player.rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            player.animator.SetTrigger("Reset");
            player.changeState(player.idleState);
            player.animator.SetFloat("Speed", 0);        
        }

    }
    
   
}

