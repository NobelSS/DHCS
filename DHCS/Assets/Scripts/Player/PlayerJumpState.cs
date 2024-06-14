using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        //player.rb.velocity = Vector2.zero;
        //player.animator.SetBool("Dive", true);
        Debug.Log("ello from playerjumpstaet");
        Vector2 diveForce = new Vector2(0f, player.diveForce / 2);
        player.rb.velocity += diveForce;
        AudioManager.Instance.PlaySFX("jump");

    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        
        float moveInput = Input.GetAxis("Horizontal");



        if (moveInput != 0)
        {
            player.rb.velocity = new Vector2(moveInput * 3f, player.rb.velocity.y);

            if (moveInput > 0)
            {
                player.rb.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (moveInput < 0)
            {
                player.rb.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        

        if (Input.GetButton("Fire3") && !player.moveState.isStaminaDepleted)
        {
            player.changeState(player.duckState);
            
        }

        if (Mathf.Abs(player.rb.velocityY) < 0.01f)
        {
            player.changeState(player.idleState);
        }
    }
}
