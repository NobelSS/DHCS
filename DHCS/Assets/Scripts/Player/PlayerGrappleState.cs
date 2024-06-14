using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrappleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("PlayerGrappleState");
        GameObject[] grapplePoints = GameObject.FindGameObjectsWithTag("GrapplePoint");

        // Find the closest grapple point to the player
        GameObject closestGrapplePoint = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject grapplePoint in grapplePoints) {
            float distance = Vector2.Distance(player.transform.position, grapplePoint.transform.position);
            if (distance < closestDistance) {
                closestDistance = distance;
                closestGrapplePoint = grapplePoint;
            }
        }

        if (closestGrapplePoint != null) {
            Vector2 targetPos = (Vector2)closestGrapplePoint.transform.position;

            player.lineRenderer.SetPosition(0, targetPos);
            player.lineRenderer.SetPosition(1, player.transform.position);
            player.distanceJoint.connectedAnchor = targetPos;
        }
        player.distanceJoint.enabled = true;
        player.lineRenderer.enabled = true;

        AudioManager.Instance.PlaySFX("grapple");
    }

    public override void ExitState(PlayerStateManager player)
    {
        player.distanceJoint.enabled = false;
        player.lineRenderer.enabled = false;

        Vector2 diveForce = new Vector2(player.rb.velocity.x * 0.5f, player.rb.velocity.y * 0.5f);
        player.rb.velocity += diveForce;
        Debug.Log("velocity X: " + player.rb.velocity.x);
        Debug.Log("velocity Y: " + player.rb.velocity.y);

        AudioManager.Instance.PlaySFX("snapback");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        float horizontalDirection = Mathf.Sign(player.rb.velocityX);
        if (horizontalDirection > 0)
        {
            player.transform.right = Vector2.right;
        }
        else
        {
            player.transform.right = Vector2.left; 
        }
        if (Input.GetButtonUp("Fire1"))
        {
            player.changeState(player.fallState);
        }
        if (player.distanceJoint.enabled)
        {
            player.lineRenderer.SetPosition(1, player.transform.position);
        }
    }
}
