using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDuckState : PlayerBaseState
{
    private float friction = 20f;
    public override void EnterState(PlayerStateManager player)
    {
        AudioManager.Instance.PlaySFX("dive");        
        player.rb.velocity = Vector2.zero;
        //player.animator.SetBool("Dive", true);
        // Debug.Log("ello from playerdukcstaet");
        Vector3 lookDirection = player.rb.transform.right;
        float diveDirection = Mathf.Sign(lookDirection.x);
        Debug.Log(lookDirection);
        Vector2 diveForce = new Vector2(diveDirection * player.diveForce, player.diveForce/3);
        player.moveState.currentStamina = 0f;
        player.rb.velocity = diveForce;
    }

    public override void ExitState(PlayerStateManager player)
    {
        //player.animator.SetBool("Dive", false);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.changeState(player.fallState);
        //Debug.Log(player.rb.velocityX);
        //    if (Mathf.Abs(player.rb.velocityY) < 0.01f)
        //    {
        //        if (player.rb.transform.right.x == 1f)
        //        {
        //            if (player.rb.velocityX > 0.01f)
        //            {
        //                player.rb.velocityX -= friction * Time.deltaTime;
        //            }
        //            else
        //            {
        //                player.changeState(player.idleState);
        //            }
        //        }
        //        else
        //        {
        //            if (player.rb.velocityX < -0.01f)
        //            {
        //                player.rb.velocityX += friction * Time.deltaTime;
        //            }
        //            else
        //            {
        //                player.changeState(player.idleState);
        //            }
        //        }
        //    }
        //}
    }
}
