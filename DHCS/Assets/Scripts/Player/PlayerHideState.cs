using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHideState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.transform.position = player.detectedTable.transform.position;
        player.rb.velocity = Vector2.zero;
    }

    public override void ExitState(PlayerStateManager player)
    {
        Debug.Log("You Are Not Hiding Anymore");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            player.changeState(player.idleState);
        }
    }
}
