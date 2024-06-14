using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("ello from idel staet");
    }

    public override void ExitState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //player.staminaBar.SetStamina(player.moveState.  currentStamina);
        
        float moveInput = Input.GetAxis("Horizontal");
       
        if (Input.GetButton("Jump"))
        {
            player.changeState(player.jumpState);
        }    

        if (Mathf.Abs(moveInput) > 0.01f)
        {
            player.changeState(player.moveState);
        }

         if(moveInput == 0)
         {
           player.moveState.Regen();
           
           
         }
        
        
    }
}
